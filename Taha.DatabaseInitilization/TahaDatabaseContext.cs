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
        public DbSet<tbl_Detail> tbl_detail { get; set; }
        public DbSet<tbl_ProductDetailAssignment> tbl_ProductDetailAssignment { get; set; }


        public DbSet<tbl_Product> tbl_Produc { get; set; }
        public DbSet<tbl_Store> tbl_Store { get; set; }
        public DbSet<tbl_Coding> tbl_Coding { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new tbl_DetailMap());
            modelBuilder.Configurations.Add(new tbl_CategoryMap());
            modelBuilder.Configurations.Add(new tbl_PlaceMap());

            modelBuilder.Configurations.Add(new tbl_ProductMap());
            modelBuilder.Configurations.Add(new tbl_StoreMap());
            modelBuilder.Configurations.Add(new tbl_CodingMap());

        }
    }
}
