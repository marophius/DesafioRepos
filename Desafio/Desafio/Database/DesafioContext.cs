using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Database
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) :base(options)
        {

        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
    }
}
