using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentNewsSite.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


    }
}