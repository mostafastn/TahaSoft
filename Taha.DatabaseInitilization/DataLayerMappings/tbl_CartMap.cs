using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_CartMap : EntityTypeConfiguration<tbl_Cart>
    {
        public tbl_CartMap()
        {
            HasMany(e => e.CartItem)
                .WithRequired(e => e.Cart)
                .HasForeignKey(e => e.fldCartID)
                .WillCascadeOnDelete(false);
        }
    }
}
