using System.Data.Entity;
using Taha.DatabaseInitilization.DataLayerMappings;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.DBContext;

namespace Taha.DatabaseInitilization
{
    public class TahaDatabaseContext : BaseContext<TahaDatabaseContext, Migrations.Configuration>
    {

        public DbSet<tbl_Category> tbl_Category { get; set; }
        public DbSet<tbl_Place> tbl_Place { get; set; }
        public DbSet<tbl_CarouselSlide> tbl_CarouselSlide { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new tbl_CategoryMap());
            modelBuilder.Configurations.Add(new tbl_PlaceMap());

        }
    }
}
