using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Taha.Core.Repository;
using Taha.DatabaseInitilization;
using Taha.Domains;
using Taha.Framework.Repository;

namespace Taha.Repository
{
    class ProductRepository : BaseRepository<TahaDatabaseContext, Product>
    {

    }
}
