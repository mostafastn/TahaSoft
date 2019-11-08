using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_CategoryMap : EntityTypeConfiguration<tbl_Category>
    {
        public tbl_CategoryMap()
        {
            HasMany(e => e.ChilList)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.fldParentID);

            HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.fldCategoryID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.CategoryAssignment)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.fldCategoryID)
                .WillCascadeOnDelete(false);
            
        }
    }
}
