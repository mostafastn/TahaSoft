using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    class tbl_PersonMap : EntityTypeConfiguration<tbl_Person>
    {
        public tbl_PersonMap()
        {
            HasOptional(e => e.User)
                .WithRequired(e => e.Person);

            HasOptional(e => e.Customer)
                .WithRequired(e => e.Person);
        }

    }
}
