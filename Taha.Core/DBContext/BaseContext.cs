using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Taha.Core.DBContext
{
    public class BaseContext<TContext, TConfig> : DbContext
        where TContext : DbContext
        where TConfig : DbMigrationsConfiguration<TContext>, new()
    {
        static BaseContext()
        {
            
            //Database.SetInitializer<TContext>(new DropCreateDatabaseIfModelChanges<TContext>());

            Database.SetInitializer<TContext>(new MigrateDatabaseToLatestVersion<TContext, TConfig>());
        }
        protected BaseContext()
          : base("name=TahaSoftConnection")
        { }
    }
}
