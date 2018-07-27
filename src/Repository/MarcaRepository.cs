using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using Sigma.PatrimonioApi.Entities.Models;

namespace Sigma.PatrimonioApi.Repository
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
