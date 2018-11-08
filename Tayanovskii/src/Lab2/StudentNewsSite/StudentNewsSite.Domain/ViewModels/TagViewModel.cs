using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewsSite.Domain.ViewModels
{
    public class TagViewModel
    {
        public string Name { get; set; }
        public virtual IEnumerable<PostViewModel> Posts { get; set; }
    }
}
