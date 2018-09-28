using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Taha.DatabaseInitilization;
using Taha.Domains;
using Taha.Framework.Repository;

namespace Taha.Repository
{
    class ProductRepository : IRepository<Product>
    {
        public RepositoryResult<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null, 
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, 
            params Expression<Func<Product, object>>[] np)
        {
            var resylt = new RepositoryResult<IEnumerable<Product>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };
            try
            {
                using (var context = new TahaDatabaseContext())
                {
                    var query = context.Products.AsQueryable();
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


            }
            catch (Exception ex)
            {
                resylt.Message = ex.Message;
            }

            return resylt;
        }

        public RepositoryResult<Product> Delete(List<Guid> ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Product> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Product> GetSingel(Expression<Func<Product, bool>> where, params Expression<Func<Product, object>>[] np)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Product> Insert(List<Product> value)
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Product> Save()
        {
            throw new NotImplementedException();
        }

        public RepositoryResult<Product> Update(List<Product> value)
        {
            throw new NotImplementedException();
        }
    }
}
