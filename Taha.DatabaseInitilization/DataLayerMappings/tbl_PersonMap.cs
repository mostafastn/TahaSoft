using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_PersonMap : EntityTypeConfiguration<tbl_Person>
    {
        public tbl_PersonMap()
        {
            HasMany(e => e.User)
                .WithRequired(e => e.Person)
                .HasForeignKey(e=>e.fldPersonID)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.Customer)
                .WithRequired(e => e.Person);
        }

    }
}
