using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_UserMap : EntityTypeConfiguration<tbl_User>
    {
        public tbl_UserMap()
        {
            HasMany(e => e.Receipt)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fldUserID)
                .WillCascadeOnDelete(false);
        }

    }
}
