using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_ProductMap : EntityTypeConfiguration<tbl_Product>
    {
        public tbl_ProductMap()
        {
            HasMany(e => e.CartItem)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.fldProductID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ReceiptItem)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.fldProductID)
                .WillCascadeOnDelete(false);
        }

    }
}
