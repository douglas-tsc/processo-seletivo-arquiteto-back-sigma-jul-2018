using Microsoft.EntityFrameworkCore;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using Sigma.PatrimonioApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigma.PatrimonioApi.Repository
{
    public class PatrimonioRepository : RepositoryBase<Patrimonio>, IPatrimonioRepository
    {
        public PatrimonioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        private static DateTime now = DateTime.Now;

        private static List<Patrimonio> _patrimonios = new List<Patrimonio> {
            new Patrimonio {
                PatrimonioId = 1,
                Nome = "Patrimonio-1",
                Descricao = "Descrição-1",
                DataCriacao = now,
                MarcaId = 1,
                Marca = new Marca { MarcaId = 1, Nome = "Marca01", DataCriacao = now },
                ModeloId = 1,
                Modelo = new Modelo { ModeloId = 1, Nome = "Modelo01", DataCriacao = now }
            },
            new Patrimonio {
                PatrimonioId = 2,
                Nome = "Patrimonio-2",
                Descricao = "Descrição-2",
                DataCriacao = now,
                MarcaId = 2,
                Marca = new Marca { MarcaId = 2, Nome = "Marca02", DataCriacao = now },
                ModeloId = 1,
                Modelo = new Modelo { ModeloId = 1, Nome = "Modelo01", DataCriacao = now }
            }
        };

        public List<Patrimonio> ObterPatrimonios()
        {
            return _patrimonios;
        }

        public Patrimonio ObterPatrimonioPorId(int id)
        {
            return _patrimonios.Where(x => x.PatrimonioId == id).FirstOrDefault();
        }

        public Patrimonio ObterPatrimonioPorMarca(string nomeMarca)
        {
            return _patrimonios.Where(x => x.Marca.Nome == nomeMarca).FirstOrDefault();
        }

        public Patrimonio ObterPatrimonioPorModelo(string nomeModelo)
        {
            return _patrimonios.Where(x => x.Modelo.Nome == nomeModelo).FirstOrDefault();
        }

        protected virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patrimonio>()
                 .Property(x => new {  x.MarcaId, x.ModeloId, x.Nome, x.Descricao }).IsRequired();

            modelBuilder.Entity<Patrimonio>()
              .HasOne(x => x.Marca);

            modelBuilder.Entity<Patrimonio>()
              .HasOne(x => x.Modelo);
        }

    }
}
