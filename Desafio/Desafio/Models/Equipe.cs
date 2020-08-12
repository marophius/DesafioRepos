using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string NomeGestor { get; set; }
        [Required]
        [MinLength(3)]
        public string NomeEquipe { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
