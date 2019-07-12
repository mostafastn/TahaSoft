using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_CustomerMap : EntityTypeConfiguration<tbl_Customer>
    {
        public tbl_CustomerMap()
        {
            HasMany(e => e.Cart)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.fldCustomerID)
                .WillCascadeOnDelete(false);
        }

    }
}
