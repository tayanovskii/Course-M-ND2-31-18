using System;
using System.Collections.Generic;

namespace StudentNewsSite.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public virtual string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual Student Author { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}