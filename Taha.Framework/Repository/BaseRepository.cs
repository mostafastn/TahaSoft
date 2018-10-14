using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Taha.Framework.Repository;

namespace Taha.Framework.Repository
{
    public class BaseRepository<TContext, TEntyti> : IRepository<TEntyti>
        where TContext : DbContext, new()
        where TEntyti : class
    {
        private DbSet<TEntyti> entyti;


        #region attempted thread-safety using double-check locking

        private static TContext _CurentContext = null;
        private static readonly object padlock = new object();

        private static TContext curentContext
        {
            get
            {
                if (_CurentContext == null)
                {
                    lock (padlock)
                    {
                        if (_CurentContext == null)
                        {
                            _CurentContext = new TContext();
                        }
                    }
                }
                return _CurentContext;
            }
        }

        #endregion

        #region Constructor

        public BaseRepository()
        {
            entyti = curentContext.Set<TEntyti>();
        }

        #endregion

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

                resylt.succeed = true;
            }
            catch (Exception ex)
            {
                resylt.Message = ex.Message;
            }

            return resylt;
        }

        public RepositoryResult<IEnumerable<TEntyti>> Insert(List<TEntyti> value)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntyti>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (value != null && !value.Any(t => t == null))
                {
                    entyti.AddRange(value);
                    curentContext.SaveChanges();
                    resylt.Result = value;
                    resylt.succeed = true;
                }
                else
                {
                    resylt.succeed = false;
                    resylt.Message = "value or one of the items is null";
                }
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
