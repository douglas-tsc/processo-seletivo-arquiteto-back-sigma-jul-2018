using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using System;

namespace Sigma.PatrimonioApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private readonly RepositoryContext _context;
        private IPatrimonioRepository _patrimonio;
        private IMarcaRepository _marca;
        private IModeloRepository _modelo;


        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }

        public IPatrimonioRepository Patrimonios
        {
            get
            {
                if (_patrimonio == null) _patrimonio = new PatrimonioRepository(_context);
                return _patrimonio;
            }
        }

        public IMarcaRepository Marcas
        {
            get
            {
                if (_marca == null) _marca = new MarcaRepository(_context);
                return _marca;
            }
        }

        public IModeloRepository Modelos
        {
            get
            {
                if (_modelo == null) _modelo = new ModeloRepository(_context);
                return _modelo;
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
