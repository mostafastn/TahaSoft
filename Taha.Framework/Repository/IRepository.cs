using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Taha.Framework.Repository
{
    public interface IRepository<T>
       where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy">Exampel: t => t.OrderBy(u => u.Item)</param>
        /// <param name="np"></param>
        /// <returns></returns>
        RepositoryResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] np);
        RepositoryResult<T> GetByID(Guid ID);
        RepositoryResult<IEnumerable<T>> Insert(List<T> value);
        RepositoryResult<IEnumerable<T>> Update(List<T> value);
        RepositoryResult<IEnumerable<Guid>> Delete(List<Guid> ID);
        RepositoryResult<T> Save();

        RepositoryResult<T> GetSingel(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] np);

    }
}
