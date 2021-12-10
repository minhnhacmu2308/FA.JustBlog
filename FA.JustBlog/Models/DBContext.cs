using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FA.JustBlog.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("ConnectionString")
        {
             
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}