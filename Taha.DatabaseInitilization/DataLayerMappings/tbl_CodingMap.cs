using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_CodingMap : EntityTypeConfiguration<tbl_Coding>
    {
        public tbl_CodingMap()
        {

            HasMany(e => e.DetailAssignment)
                .WithRequired(e => e.Coding)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ImageAssignment)
                .WithRequired(e => e.Coding)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.CategoryAssignment)
                .WithRequired(e => e.Coding)
                .HasForeignKey(e => e.fldCodingID)
                .WillCascadeOnDelete(false);
        }

    }
}
