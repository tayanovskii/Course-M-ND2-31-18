using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.API.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

    }
}
