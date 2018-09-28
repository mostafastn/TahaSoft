using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Taha.Framework.Repository;
using Taha.DatabaseInitilization;

namespace Taha.Core.Repository
{
    public class BaseRepository<TContext, TEntyti> : IRepository<TEntyti>
        where TContext : DbContext ,new()
        where TEntyti : class
    {
        private TContext context;
        private DbSet<TEntyti> entyti;

        public BaseRepository()
        {
            context = new TContext();
            entyti = context.Set<TEntyti>();
        }

        public RepositoryResult<IEnumerable<TEntyti>> GetAll(Expression<Func<TEntyti, bool>> filter = null, Func<IQueryable<TEntyti>, IOrderedQueryable<TEntyti>> orderBy = null, params Expression<Func<TEntyti, object>>[] np)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntyti>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                using (var context = new TContext())
                {
                    var query = entyti.AsQueryable();
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

        public RepositoryResult<TEntyti> Delete(List<Guid> ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntyti> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntyti> GetSingel(Expression<Func<TEntyti, bool>> where, params Expression<Func<TEntyti, object>>[] np)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntyti> Insert(List<TEntyti> value)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntyti> Save()
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntyti> Update(List<TEntyti> value)
        {
            throw new NotImplementedException();
        }
    }
}
