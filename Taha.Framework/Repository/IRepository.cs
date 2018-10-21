using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taha.Framework.Repository
{
    public interface IRepository<T>
       where T : class
    {

        RepositoryResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] np);
        RepositoryResult<T> GetByID(Guid ID);
        RepositoryResult<IEnumerable<T>> Insert(List<T> value);
        RepositoryResult<T> Update(T value);
        RepositoryResult<IEnumerable<T>> Update(List<T> value);
        RepositoryResult<T> Delete(List<Guid> ID);
        RepositoryResult<T> Save();

        RepositoryResult<T> GetSingel(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] np);

    }
}
