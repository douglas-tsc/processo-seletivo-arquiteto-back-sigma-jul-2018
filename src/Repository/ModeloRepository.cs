using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using Sigma.PatrimonioApi.Entities.Models;

namespace Sigma.PatrimonioApi.Repository
{
    public class ModeloRepository : RepositoryBase<Modelo>, IModeloRepository
    {
        public ModeloRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
