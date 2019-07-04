using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_Product_XMap : EntityTypeConfiguration<tbl_Product_X>
    {
        public tbl_Product_XMap()
        {
            HasOptional(e => e.tbl_B)
                .WithRequired(e => e.tbl_A);
        }

    }
}
