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
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentNewsSiteContext>());
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

            var post = modelBuilder.Entity<Post>();
            post.HasKey(p => p.Id);
            post.Property(p => p.Content).IsRequired().IsUnicode();
            post.Property(p => p.Created).IsRequired().HasColumnType("datetime");

            var tag = modelBuilder.Entity<Tag>();
            tag.HasKey(t => t.Id);
            tag.Property(t => t.Name).IsRequired().HasMaxLength(30).IsUnicode();

            var comment = modelBuilder.Entity<Comment>();
            comment.HasKey(c => c.Id);
            comment.Property(c => c.Content).IsRequired().IsUnicode();
            comment.Property(c => c.Created).IsRequired().HasColumnType("datetime");

        }

        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }


    }
}
