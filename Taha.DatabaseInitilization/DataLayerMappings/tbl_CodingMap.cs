using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_CodingMap : EntityTypeConfiguration<tbl_Coding>
    {
        public tbl_CodingMap()
        {
            HasMany(e => e.ProductDetailAssignment)
                .WithRequired(e => e.Coding_X)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);
        }

    }
}
