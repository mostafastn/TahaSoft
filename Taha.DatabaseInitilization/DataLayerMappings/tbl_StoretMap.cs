using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_StoreMap : EntityTypeConfiguration<tbl_Store>
    {
        public tbl_StoreMap()
        {
            HasMany(e => e.DetailAssignment)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.CategoryAssignment)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ImageAssignment)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);
        }

    }
}
