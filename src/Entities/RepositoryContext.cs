using Microsoft.EntityFrameworkCore;
using Sigma.PatrimonioApi.Entities.Models;

namespace Sigma.PatrimonioApi.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

    }
}
