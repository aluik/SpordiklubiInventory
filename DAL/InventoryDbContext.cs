using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class InventoryDbContext : DbContext, IDbContext
    {
        public InventoryDbContext() : base("DbConnectionString")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<InventoryDbContext, MigrationConfiguration>());
#if DEBUG
            // Enable database loggind to trace console
            // to see output, start project in debug mode
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Renting> Rentings { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<Footwear> Footwears { get; set; }
        public DbSet<FootwearType> FootwearTypes { get; set; }


    }
}
