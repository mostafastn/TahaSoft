using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_PlaceMap : EntityTypeConfiguration<tbl_Place>
    {
        public tbl_PlaceMap()
        {
            HasMany(e => e.ChilList)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.fldParentID);


        }
    }
}
