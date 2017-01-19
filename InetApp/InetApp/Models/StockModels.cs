using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InetApp.Models
{
    public class StockContext : DbContext
    {
        public StockContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Depot> Depots { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Pur_strings> Pur_stringss { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Paynment> Paynments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}