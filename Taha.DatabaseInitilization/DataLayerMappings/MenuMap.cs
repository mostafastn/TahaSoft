using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    public class MenuMap : EntityTypeConfiguration<TBL_Menu>
    {
        public MenuMap()
        {
            //HasMany(e => e.ChilList)
            //    .WithRequired(e => e.Parent) //Each comment from Replies points back to its parent
            //    .HasForeignKey(e => e.FLDParentID);


            HasMany(e => e.ChilList)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.FLDParentID);


        }
    }
}
