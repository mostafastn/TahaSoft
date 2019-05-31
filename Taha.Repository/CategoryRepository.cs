using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;

namespace Taha.Repository
{
    public class CategoryRepository : BaseRepository<TahaDatabaseContext, Category>
    {

        public RepositoryResult<IEnumerable<object>> complicateObjectTest()
        {
            var categories = curentContext.Categories.Where(t => t.FLDDeleteDate==null ).ToList();
            
            var b = from con in curentContext.Categories
                join conn in curentContext.Categories on con.Periority equals conn.Periority
                where con.Periority > 4
                select new
                {
                    con.Name,
                    con.Periority,
                    connName =conn.Name,
                    connPeriority =conn.Periority
                };

            return new RepositoryResult<IEnumerable<object>>()
            {
                Result = b,
                succeed = true,
                Message = ""
            };
        }
    }
}
