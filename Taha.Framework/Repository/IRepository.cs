using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taha.Framework.Repository
{
    public interface IRepository<T, U>
       where T : class
       where U : class
    {

        RepositoryResult<IEnumerable<U>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] np);
        RepositoryResult<U> GetByID(Guid ID);
        RepositoryResult<IEnumerable<U>> Insert(List<U> value);
        RepositoryResult<IEnumerable<U>> Update(List<U> value);
        RepositoryResult<IEnumerable<Guid>> Delete(List<Guid> ID);
        RepositoryResult<U> Save();

        RepositoryResult<U> GetSingel(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] np);

    }
}
