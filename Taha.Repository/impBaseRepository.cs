using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Repository;
using Taha.DatabaseInitilization;
using Taha.Domains;

namespace Taha.Repository
{
    public class impBaseRepository : BaseRepository<TahaDatabaseContext,Category>
    {
        public impBaseRepository()
        {
            
        }
    }
}
