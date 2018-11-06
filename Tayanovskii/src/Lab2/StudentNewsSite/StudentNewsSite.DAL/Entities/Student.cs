using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentNewsSite.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }


    }
}