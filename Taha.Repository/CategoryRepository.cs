using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Taha.DatabaseInitilization;
using Taha.Domains;
using Taha.Framework.Repository;

namespace Taha.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        public RepositoryResult<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>> filter = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
            params Expression<Func<Category, object>>[] np)
        {
            var resylt = new RepositoryResult<IEnumerable<Category>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };
            try
            {
                using (var context = new TahaDatabaseContext())
                {
                    var query = context.Categories.AsQueryable();
                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }
                    if (orderBy != null)
                    {
                        query = orderBy(query);
                    }

                    resylt.Result = query.ToList();
                }
                resylt.succeed = true;

            }
            catch (Exception ex)
            {
                resylt.Message = ex.Message;
            }

            return resylt;
        }

        public RepositoryResult<Category> Delete(List<Guid> ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Category> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Category> GetSingel(Expression<Func<Category, bool>> where, params Expression<Func<Category, object>>[] np)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Category> Insert(List<Category> value)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Category> Save()
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Category> Update(List<Category> value)
        {
            throw new NotImplementedException();
        }
    }
}
