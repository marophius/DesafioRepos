using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Models;
using Desafio.Repositorios.Contratos;
using Desafio.ViewModel;
using Desafio.Database;

namespace Desafio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        private readonly IEquipeRepositorio _equipeRepositorio;
        private readonly DesafioContext _context;

        public HomeController(IColaboradorRepositorio colaboradorRepositorio, IEquipeRepositorio equipeRepositorio, DesafioContext context)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
            _equipeRepositorio = equipeRepositorio;
            _context = context;
        }

        public IActionResult Index()
        {
            List<HomeIndexViewModel> listaGridVM = new List<HomeIndexViewModel>();
            var lista = (from Equipes in _context.Equipes
                         join Colab in _context.Colaboradores on Equipes.Id equals Colab.EquipeId
                         select new {Equipes.NomeEquipe, Equipes.NomeGestor, Colab.Nome, Colab.Id}).ToList();

            // Se a equipe não tem colaboradores ela não vai aparecer,
            // Mas ela pode ser vista na tela de "Gerenciar Equipes" 
           
            foreach(var item in lista)
            {
                HomeIndexViewModel hm = new HomeIndexViewModel();
                hm.EquipeNome = item.NomeEquipe;
                hm.GestorNome = item.NomeGestor;
                hm.ColaboradorNome = item.Nome;
                hm.ColaboradorId = item.Id;
                listaGridVM.Add(hm);
            }
            
            return View(listaGridVM);
        }

        [HttpGet]
        public IActionResult CadastrarColaborador()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult CadastrarColaborador([FromForm] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _colaboradorRepositorio.Cadastrar(colaborador);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(CadastrarColaborador));
        }

        [HttpGet]
        public IActionResult CadastrarEquipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarEquipe([FromForm] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _equipeRepositorio.Cadastrar(equipe);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(CadastrarEquipe));
        }

        [HttpGet]
        public IActionResult ExcluirColaborador(int id)
        {
            _colaboradorRepositorio.Excluir(id);
            TempData["MSG_S"] = "Registro excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Equipes()
        {
            List<Equipe> list = _equipeRepositorio.ObterTodas();
            return View(list);
        }

        [HttpGet]
        public IActionResult ExcluirEquipe(int id)
        {
            _equipeRepositorio.Excluir(id);
            TempData["MSG_S"] = "Registro excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AtualizarEquipe(int id)
        {
            var equipeById = _equipeRepositorio.ObterEquipe(id);
            return View(equipeById);
        }

        [HttpPost]
        public IActionResult AtualizarEquipe([FromForm] Equipe equipe, int id)
        {
            if (ModelState.IsValid)
            {
                _equipeRepositorio.Atualizar(equipe);
                TempData["MSG_S"] = "Registro atualizado com sucesso";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult AtualizarColaborador(int id)
        {
            var colaboradorById = _colaboradorRepositorio.ObterColaborador(id);

            return View(colaboradorById);
        }


        [HttpPost]
        public IActionResult AtualizarColaborador([FromForm] Colaborador colaborador, int id)
        {
            if (ModelState.IsValid)
            {
                _colaboradorRepositorio.Atualizar(colaborador);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        //[HttpGet]
        //public IActionResult ExcluirColaboradorHM(int id)
        //{
        //    _colaboradorRepositorio.Excluir(id);

        //}

    }
}
