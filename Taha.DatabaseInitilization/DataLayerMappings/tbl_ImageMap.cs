using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_ImageMap : EntityTypeConfiguration<tbl_Image>
    {
        public tbl_ImageMap()
        {
            HasMany(e => e.ImageAssignment)
                .WithRequired(e => e.Image)
                .HasForeignKey(e => e.fldImageID)
                .WillCascadeOnDelete(false);
        }
    }
}
