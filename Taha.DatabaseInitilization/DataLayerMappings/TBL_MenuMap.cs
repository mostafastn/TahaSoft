using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class TBL_MenuMap : EntityTypeConfiguration<TBL_Menu>
    {
        public TBL_MenuMap()
        {
            HasMany(e => e.ChilList)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.fldParentID);


        }
    }
}
