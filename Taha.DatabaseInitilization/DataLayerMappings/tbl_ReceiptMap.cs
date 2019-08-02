using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_ReceiptMap : EntityTypeConfiguration<tbl_Receipt>
    {
        public tbl_ReceiptMap()
        {
            HasMany(e => e.ReceiptItem)
                .WithRequired(e => e.Receipt)
                .HasForeignKey(e => e.fldReceiptID)
                .WillCascadeOnDelete(false);
        }
    }
}
