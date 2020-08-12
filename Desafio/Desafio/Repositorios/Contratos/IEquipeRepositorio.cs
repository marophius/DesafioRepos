using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Desafio.Repositorios.Contratos
{
    public interface IEquipeRepositorio
    {
        void Cadastrar(Equipe equipe);
        void Atualizar(Equipe equipe);
        void Excluir(int id);
        Equipe ObterEquipe(int id);
        List<Equipe> ObterTodas();
        IPagedList<Equipe> ObterTodasEquipes(int? page);
    }
}
