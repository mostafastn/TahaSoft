using System.Data.Entity.Migrations;

namespace Taha.DatabaseInitilization.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TahaDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TahaDatabaseContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TahaDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
