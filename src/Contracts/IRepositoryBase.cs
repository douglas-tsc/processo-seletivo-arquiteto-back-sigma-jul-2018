using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sigma.PatrimonioApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = "");
        IEnumerable<T> FindAll(string[] includes);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        T GetById(object id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
