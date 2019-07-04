using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_ProductMap : EntityTypeConfiguration<tbl_Product>
    {
        public tbl_ProductMap()
        {
            HasOptional(e => e.Coding)
                .WithRequired(e => e.Product);

            //HasOptional(x => x.Coding).WithMany()
            //    .HasForeignKey(x => x.fldID);
        }
    }
}
