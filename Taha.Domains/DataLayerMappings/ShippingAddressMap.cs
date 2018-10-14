using System.Data.Entity.ModelConfiguration;
using Taha.Domains;

namespace Taha.Domains.DataLayerMappings
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
