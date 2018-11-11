using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewsSite.Domain.ViewModels
{
    public class CreatePostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual StudentViewModel Author { get; set; }
        public DateTime Created { get; set; }
        public string Tags { get; set; }
    }
}
