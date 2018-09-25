using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.DBContext;
using Taha.DataLayerMappings;
using Taha.Domains;

namespace Taha.DatabaseInitilization
{
    public class TahaDatabaseContext : BaseContext<TahaDatabaseContext, Migrations.Configuration>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LineItemMap());
            modelBuilder.Configurations.Add(new ShippingAddressMap());

        }
    }
}
