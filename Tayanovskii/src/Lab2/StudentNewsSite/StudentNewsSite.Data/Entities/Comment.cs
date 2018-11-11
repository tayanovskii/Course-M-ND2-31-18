using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewsSite.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual Student Author { get; set; }
        public virtual DateTime Created { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
