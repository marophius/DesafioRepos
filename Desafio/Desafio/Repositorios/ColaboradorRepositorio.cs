using Desafio.Database;
using Desafio.Models;
using Desafio.Repositorios.Contratos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Desafio.Repositorios
{
    public class ColaboradorRepositorio : IColaboradorRepositorio
    {
        private readonly DesafioContext _context;

        private IConfiguration _conf;
        
        public ColaboradorRepositorio(DesafioContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        public void Atualizar(Colaborador colaborador)
        {
            _context.Update(colaborador);
            _context.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _context.Add(colaborador);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Colaborador colaborador = ObterColaborador(id);
            _context.Remove(colaborador);
            _context.SaveChanges();
        }

        public Colaborador ObterColaborador(int id)
        {
            return _context.Colaboradores.Find(id);
        }

        public List<Colaborador> ObterTodos()
        {
            return _context.Colaboradores.ToList();
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? page)
        {
            int registroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPorPagina = page ?? 1;
            return _context.Colaboradores.ToPagedList<Colaborador>(numeroPorPagina, registroPorPagina);
        }
    }
}
