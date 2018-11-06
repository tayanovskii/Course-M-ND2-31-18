using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewsSite.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Student Author { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
