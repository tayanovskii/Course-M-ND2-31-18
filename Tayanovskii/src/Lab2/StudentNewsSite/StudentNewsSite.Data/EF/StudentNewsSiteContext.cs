using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentNewsSite.Data.Entities;

namespace StudentNewsSite.Data.EF
{
    public class StudentNewsSiteContext : DbContext
    {
        static StudentNewsSiteContext()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<StudentNewsSiteContext>());
        }

        public StudentNewsSiteContext( ) : base("StudentNewsSiteDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var student = modelBuilder.Entity<Student>();
            student.HasKey(s => s.Id);
            student.Property(s => s.FirstName).IsRequired().IsUnicode();
            student.Property(s => s.LastName).IsRequired().IsUnicode();

        }

        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }


    }
}
