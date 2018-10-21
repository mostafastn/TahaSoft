using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Taha.Framework.Entity;

namespace Taha.Framework.Repository
{
    public class BaseRepository<TContext, TEntyti> : IRepository<TEntyti>
        where TContext : DbContext, new()
        where TEntyti : BaseEntity
    {
        private DbSet<TEntyti> entyti;

        #region Singleton - using .NET 4's Lazy<T> type

        private static readonly Lazy<TContext> lazy =
            new Lazy<TContext>(() => new TContext());
        public static TContext curentContext { get { return lazy.Value; } }

        #endregion

        #region Constructor

        protected BaseRepository()
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

        public RepositoryResult<TEntyti> Update(TEntyti value)
        {
            var resylt = new RepositoryResult<TEntyti>()
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

        public RepositoryResult<IEnumerable<TEntyti>> Update(List<TEntyti> value)
        {
            var resylt = new RepositoryResult<IEnumerable<TEntyti>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                var valueIDs = value.Select(t => t.ID);
                var objs = entyti.Where(t => valueIDs.Contains(t.ID)).ToList();

                //TODO :: Check if any object find

                if (valueIDs != null && objs != null)
                {
                    objs.ForEach(t =>
                    {
                        var a = value.Where(u => u.ID == t.ID);
                        curentContext.Entry(t).CurrentValues.SetValues(a);
                    });
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
    }
}
