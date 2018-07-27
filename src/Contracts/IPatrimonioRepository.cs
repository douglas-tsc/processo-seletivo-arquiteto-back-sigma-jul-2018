using Sigma.PatrimonioApi.Entities.Models;

namespace Sigma.PatrimonioApi.Contracts
{
    public interface IPatrimonioRepository : IRepositoryBase<Patrimonio>
    {
        Patrimonio ObterPatrimonioPorId(int id);

        Patrimonio ObterPatrimonioPorMarca(string nomeMarca);

        Patrimonio ObterPatrimonioPorModelo(string nomeModelo);

    }
}
