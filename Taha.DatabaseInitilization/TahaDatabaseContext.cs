using System.Data.Entity;
using Taha.DatabaseInitilization.DataLayerMappings;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.DBContext;

namespace Taha.DatabaseInitilization
{
    public class TahaDatabaseContext : BaseContext<TahaDatabaseContext, Migrations.Configuration>
    {
        #region Main Object

        public DbSet<tbl_Person> Tbl_Persons { get; set; }
        public DbSet<tbl_User> Tbl_Users { get; set; }

        public DbSet<tbl_Category> tbl_Category { get; set; }
        public DbSet<tbl_Place> tbl_Place { get; set; }
        public DbSet<tbl_CarouselSlide> tbl_CarouselSlide { get; set; }
        public DbSet<tbl_Product> tbl_Produc { get; set; }
        public DbSet<tbl_Store> tbl_Store { get; set; }
        public DbSet<tbl_Cart> tbl_Cart { get; set; }
        public DbSet<tbl_Customer> tbl_Customer { get; set; }

        public DbSet<tbl_Detail> tbl_detail { get; set; }
        public DbSet<tbl_Image> tbl_Image { get; set; }

        #endregion

        #region tbl_CodingMap

        public DbSet<tbl_Coding> tbl_Coding { get; set; }

        #endregion

        #region ObjectAssignment

        public DbSet<tbl_DetailAssignment> tbl_DetailAssignment { get; set; }
        public DbSet<tbl_ImageAssignment> tbl_ImageAssignment { get; set; }
        public DbSet<tbl_CategoryAssignment> tbl_CategoryAssignment { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_CodingMap());

            modelBuilder.Configurations.Add(new tbl_PersonMap());
            modelBuilder.Configurations.Add(new tbl_CustomerMap());
            modelBuilder.Configurations.Add(new tbl_CartMap());
            modelBuilder.Configurations.Add(new tbl_ReceiptMap());
            modelBuilder.Configurations.Add(new tbl_DetailMap());
            modelBuilder.Configurations.Add(new tbl_ImageMap());
            modelBuilder.Configurations.Add(new tbl_CategoryMap());
            modelBuilder.Configurations.Add(new tbl_PlaceMap());
            modelBuilder.Configurations.Add(new tbl_UserMap());
            modelBuilder.Configurations.Add(new tbl_ProductMap());
            modelBuilder.Configurations.Add(new tbl_StoreMap());
        }
    }
}
