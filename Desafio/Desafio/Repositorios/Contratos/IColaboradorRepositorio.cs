using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Desafio.Repositorios.Contratos
{
    public interface IColaboradorRepositorio
    {
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void Excluir(int id);
        Colaborador ObterColaborador(int id);
        List<Colaborador> ObterTodos();
        IPagedList<Colaborador> ObterTodosColaboradores(int? page);
    }
}
