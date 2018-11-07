using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentNewsSite.BLL.ViewModels;

namespace StudentNewsSite.Data.Entities
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public StudentViewModel Author { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
        public virtual IEnumerable<TagViewModel> Tags { get; set; }
    }
}
