using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_DetailMap : EntityTypeConfiguration<tbl_Detail>
    {
        public tbl_DetailMap()
        {
            HasMany(e => e.DetailAssignment)
                .WithRequired(e => e.Detail)
                .HasForeignKey(e => e.fldDetailID)
                .WillCascadeOnDelete(false);
        }
    }
}
