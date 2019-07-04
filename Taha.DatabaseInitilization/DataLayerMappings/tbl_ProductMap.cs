using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_ProductMap : EntityTypeConfiguration<tbl_Product>
    {
        public tbl_ProductMap()
        {
            HasOptional(e => e.tbl_Coding)
                .WithRequired(e => e.tbl_Product);
        }
    }
}
