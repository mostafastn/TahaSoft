using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    public class ShippingAddressMap : EntityTypeConfiguration<ShippingAddress>
    {
        public ShippingAddressMap()
        {
            HasRequired(t => t.Customer)
              .WithOptional(t => t.ShippingAddress);
        }
    }
}
