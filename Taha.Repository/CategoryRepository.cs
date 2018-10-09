using System;
using Taha.Core.Repository;
using Taha.DatabaseInitilization;
using Taha.Domains;

namespace Taha.Repository
{
    public class CategoryRepository : BaseRepository<TahaDatabaseContext, Category>
    {
        public object GetAll(Func<object, object> orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
