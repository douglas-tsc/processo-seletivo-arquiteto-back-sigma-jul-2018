namespace Sigma.PatrimonioApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IPatrimonioRepository Patrimonios { get; }
        IMarcaRepository Marcas { get; }
        IModeloRepository Modelos { get; }
    }
}
