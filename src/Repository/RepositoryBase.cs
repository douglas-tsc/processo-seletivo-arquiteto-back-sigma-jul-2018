using Microsoft.EntityFrameworkCore;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sigma.PatrimonioApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context { get; set; }


        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (expression != null)
                query = query.Where(expression);

            foreach (var property in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);

            return (orderBy != null) ? orderBy(query) : query;
        }

        public IEnumerable<T> FindAll(string[] includes)
        {
            return includes.Aggregate(_context.Set<T>().AsQueryable(), (query, path) => query.Include(path));
        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var type = ex.GetType();

                var builder = new StringBuilder();
                    builder.AppendFormat("A exceção DbUpdateException foi lançada ao tentar salvar as alterações.");

                foreach (var eve in ex.Entries)
                    builder.AppendFormat("A entidade do tipo {0} no estado {1} não pôde ser atualizada.", eve.Entity.GetType().Name, eve.State);

                var exMsg = ex.ToString();
                if (exMsg.Contains("The conversion of a datetime2 data type") ||
                    exMsg.Contains("A conversão de um tipo de dados datetime2"))
                    throw new DateTimeErrorException("A tentativa de conversão de um tipo de dados resultou em um valor fora do intervalo.");
                else if (
                    exMsg.Contains("The DELETE statement conflicted with the REFERENCE constraint") ||
                    exMsg.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
                    throw new ConstraintException(builder.ToString());
                else
                    throw new Exception(builder.ToString(), ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
