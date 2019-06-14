using System.Data.Entity;
using Taha.DatabaseInitilization.DataLayerMappings;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.DBContext;

namespace Taha.DatabaseInitilization
{
    public class TahaDatabaseContext : BaseContext<TahaDatabaseContext, Migrations.Configuration>
    {
      
        public DbSet<tbl_Category> tbl_Category { get; set; }

        public DbSet<TBL_Menu> TBL_Menu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            #region test
            
            modelBuilder.Configurations.Add(new TBL_MenuMap());

            #endregion

            modelBuilder.Configurations.Add(new tbl_CategoryMap());

        }
    }
}
