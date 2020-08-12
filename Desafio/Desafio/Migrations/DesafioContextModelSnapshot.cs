﻿// <auto-generated />
using System;
using Desafio.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.Migrations
{
    [DbContext(typeof(DesafioContext))]
    partial class DesafioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Desafio.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Endereco");

                    b.Property<int>("EquipeId");

                    b.Property<string>("Genero");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Desafio.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeEquipe")
                        .IsRequired();

                    b.Property<string>("NomeGestor")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Desafio.Models.Colaborador", b =>
                {
                    b.HasOne("Desafio.Models.Equipe", "Equipe")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
