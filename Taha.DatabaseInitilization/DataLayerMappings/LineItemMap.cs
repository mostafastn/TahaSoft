using System.Data.Entity.ModelConfiguration;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;

namespace Taha.DatabaseInitilization.DataLayerMappings
{
    public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            //not mapped to database
            Ignore(t => t.LineTotal);
        }
    }
}
