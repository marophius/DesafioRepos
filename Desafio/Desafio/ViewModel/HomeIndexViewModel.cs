using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.ViewModel
{
    public class HomeIndexViewModel
    {
        public int HomeIndexViewModelId { get; set; }
        public string EquipeNome { get; set; } //Equipe Nome
        public string GestorNome { get; set; } //Equipe Gestor Nome
        public string ColaboradorNome { get; set; } // Colaborador Nome
        public int ColaboradorId { get; set; }
        // public int EquipeId { get; set; }
    }
}
