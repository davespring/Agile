using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Agile.Biz.DAL
{
    public class AgileContext : DbContext
    {
        public AgileContext() : base("AgileContext")
        {

        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Subscribe> Subscriptions { get; set; }
        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}