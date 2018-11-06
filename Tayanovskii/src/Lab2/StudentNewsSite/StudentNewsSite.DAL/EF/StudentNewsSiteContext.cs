using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentNewsSite.DAL.Entities;

namespace StudentNewsSite.DAL.EF
{
    class StudentNewsSiteContext : DbContext
    {
        static StudentNewsSiteContext()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<StudentNewsSiteContext>());
        }

        public StudentNewsSiteContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
