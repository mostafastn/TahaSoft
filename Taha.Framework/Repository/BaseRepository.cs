using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Taha.Framework.Entity;

namespace Taha.Framework.Repository
{
    public class BaseRepository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : BaseEntity
    {
        private DbSet<TEntity> entyti;

        #region Singleton - using .NET 4's Lazy<T> type

        private static readonly Lazy<TContext> lazy =
            new Lazy<TContext>(() => new TContext());
        public static TContext curentContext { get { return lazy.Value; } }

        #endregion

        #region Constructor

        protected BaseRepository()
        {
            entyti = curentContext.Set<TEntity>();
        }
        #endregion


        public RepositoryResult<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] np)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntity>>()
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

        public RepositoryResult<IEnumerable<TEntity>> Insert(List<TEntity> value)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntity>>()
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

        public RepositoryResult<TEntity> Update(TEntity value)
        {
            var resylt = new RepositoryResult<TEntity>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                var obj = entyti.FirstOrDefault(t => t.ID == value.ID);

                if (value != null && obj != null)
                {
                    curentContext.Entry(obj).CurrentValues.SetValues(value);
                    curentContext.SaveChanges();
                    resylt.Result = value;
                    resylt.succeed = true;
                }
                else
                {
                    resylt.succeed = false;
                    resylt.Message = "value is null";
                }
            }
            catch (Exception ex)
            {
                resylt.Message = ex.Message;
            }

            return resylt;
        }

        public RepositoryResult<IEnumerable<TEntity>> Update(List<TEntity> value)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntity>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (value != null)
                {
                    var failList = new List<TEntity>();

                    value.ForEach(t =>
                     {
                         var obj = entyti.FirstOrDefault(u => u.ID == t.ID);
                         if (obj != null)
                             curentContext.Entry(obj).CurrentValues.SetValues(t);
                         else
                             failList.Add(t);
                     });

                    if (failList != null)
                    {
                        resylt.Result = failList;
                        resylt.succeed = false;
                        resylt.Message = "cannot find this values in database";
                    }

                    curentContext.SaveChanges();
                    resylt.Result = value;
                    resylt.succeed = true;
                }
                else
                {
                    resylt.succeed = false;
                    resylt.Message = "value is null";
                }
            }
            catch (Exception ex)
            {
                resylt.Message = ex.Message;
            }

            return resylt;
        }


        public RepositoryResult<TEntity> Delete(List<Guid> ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntity> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntity> GetSingel(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] np)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<TEntity> Save()
        {
            throw new NotImplementedException();
        }
    }
}
