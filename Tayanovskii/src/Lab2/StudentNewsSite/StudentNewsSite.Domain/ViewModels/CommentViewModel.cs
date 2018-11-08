using System;

namespace StudentNewsSite.Domain.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public virtual StudentViewModel Author { get; set; }
        public DateTime Created { get; set; }
        public virtual PostViewModel Post { get; set; }

    }
}
