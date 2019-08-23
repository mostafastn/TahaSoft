using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_StoreMap : EntityTypeConfiguration<tbl_Store>
    {
        public tbl_StoreMap()
        {
            //HasOptional(e => e.Coding)
            //    .WithRequired(e => e.Store);

            //after delete Coding
            HasMany(e => e.DetailAssignment)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);
        }

    }
}
