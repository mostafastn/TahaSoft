using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Taha.Framework.Entity;

namespace Taha.Framework.Repository
{
    public abstract class BaseRepository<TContext, TEntity, TModel> : IRepository<TModel>
        where TContext : DbContext, new()
        where TEntity : BaseEntity
        where TModel : class
    {
        private DbSet<TEntity> curentRepository;

        #region Singleton - using .NET 4's Lazy<T> type

        private static readonly Lazy<TContext> lazy =
            new Lazy<TContext>(() => new TContext());

        public static TContext curentContext
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion

        #region Constructor

        protected BaseRepository()
        {
            curentRepository = curentContext.Set<TEntity>();
        }

        #endregion

        #region Abstract Methods

        public abstract IQueryable<TEntity> ToEntityQueryable(IQueryable<TModel> values);
        public abstract IQueryable<TModel> ToObjectQueryable(IQueryable<TEntity> values);

        #endregion

        public virtual RepositoryResult<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, params Expression<Func<TModel, object>>[] np)
        {
            var result = new RepositoryResult<IEnumerable<TModel>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {

                var query = ToObjectQueryable(curentRepository.AsQueryable());

                if (filter != null)
                    query = query.Where(filter);

                if (orderBy != null)
                    query = orderBy(query);

                result.Result = query.ToList();

                result.succeed = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual RepositoryResult<IEnumerable<TModel>> Insert(List<TModel> value)
        {
            var result = new RepositoryResult<IEnumerable<TModel>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (value != null && !value.Any(t => t == null))
                {
                    var queryable = ToEntityQueryable(value.AsQueryable());
                    curentRepository.AddRange(queryable);
                    curentContext.SaveChanges();
                    result.Result = value;
                    result.succeed = true;
                }
                else
                {
                    result.succeed = false;
                    result.Message = "value or one of the items is null";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual RepositoryResult<IEnumerable<TModel>> Update(List<TModel> value)
        {
            var result = new RepositoryResult<IEnumerable<TModel>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (value != null)
                {
                    var failList = new List<TModel>();
                    var failIDList = new List<Guid>();

                    var entityList = ToEntityQueryable(value.AsQueryable()).ToList();
                    var _ids = entityList.Select(t => t.fldID).ToList();
                    var _objs = curentRepository.Where(u => _ids.Contains(u.fldID)).ToList();

                    entityList.ToList().ForEach(t =>
                    {
                        var obj = _objs.FirstOrDefault(u => u.fldID == t.fldID);
                        if (obj != null)
                        {
                            t.fldUpdateDate = Infrastructure.Utility.Curent.Now();
                            curentContext.Entry(obj).CurrentValues.SetValues(t);
                        }
                        else
                            failIDList.Add(t.fldID);
                    });

                    var __failList = _objs.Where(t => failIDList.Contains(t.fldID));
                    failList = ToObjectQueryable(__failList.AsQueryable()).ToList();
                    //var entities = ToEntity(value).ToList();
                    //var ids = entities.Select(t => t.FLDID).ToList();
                    //var objs = entity.Where(u => ids.Contains(u.FLDID)).ToList();

                    //entities.ForEach(t =>
                    //{
                    //    var obj = objs.FirstOrDefault(u => u.FLDID == t.FLDID);
                    //    if (obj != null)
                    //        curentContext.Entry(obj).CurrentValues.SetValues(t);
                    //    else
                    //        failList.Add(ToObject( t));
                    //});

                    if (failList.Any())
                    {
                        result.Result = failList;
                        result.succeed = false;
                        result.Message = "cannot find this values in database";
                    }
                    else
                    {
                        curentContext.SaveChanges();
                        result.Result = value;
                        result.succeed = true;
                    }
                }
                else
                {
                    result.succeed = false;
                    result.Message = "value is null";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual RepositoryResult<IEnumerable<Guid>> Delete(List<Guid> IDs)
        {
            var result = new RepositoryResult<IEnumerable<Guid>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (IDs != null)
                {
                    var objs = curentRepository.Where(u => IDs.Contains(u.fldID)).ToList();
                    curentRepository.RemoveRange(objs);

                    curentContext.SaveChanges();
                    result.Result = IDs;
                    result.succeed = true;
                }
                else
                {
                    result.Message = "value is null";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual RepositoryResult<TModel> GetByID(Guid ID)
        {
            var result = new RepositoryResult<TModel>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                if (ID == Guid.Empty)
                    result.Message = "Invalid ID";
                else
                {
                    var obj = curentRepository.FirstOrDefault(t => t.fldID == ID);
                    if (obj == null)
                        result.Message = "Cannot Find this Item in Database";
                    else
                    {
                        var tEntityList = new List<TEntity>() {obj};
                        var resultModel = ToObjectQueryable(tEntityList.AsQueryable()).FirstOrDefault();
                        
                        result.Result = resultModel;
                        result.succeed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }

        public RepositoryResult<TModel> GetSingel(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] np)
        {
            throw new NotImplementedException();
        }
        public virtual RepositoryResult<TModel> Save()
        {
            throw new NotImplementedException();
        }
    }
}
