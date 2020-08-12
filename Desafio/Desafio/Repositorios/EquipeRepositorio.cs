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
    public class EquipeRepositorio : IEquipeRepositorio
    {
        private readonly DesafioContext _context;

        private IConfiguration _conf;

        public EquipeRepositorio(DesafioContext context, IConfiguration conf)
        {
            _conf = conf;
            _context = context;
        }

        public void Atualizar(Equipe equipe)
        {
            _context.Update(equipe);
            _context.SaveChanges();
        }

        public void Cadastrar(Equipe equipe)
        {
            _context.Add(equipe);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Equipe equipe = ObterEquipe(id);
            _context.Remove(equipe);
            _context.SaveChanges();
        }

        public Equipe ObterEquipe(int id)
        {
            return _context.Equipes.Find(id);
        }

        public List<Equipe> ObterTodas()
        {
            return _context.Equipes.ToList();
        }

        public IPagedList<Equipe> ObterTodasEquipes(int? page)
        {
            int registroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = page ?? 1;
            return _context.Equipes.ToPagedList<Equipe>();
        }
    }
}
