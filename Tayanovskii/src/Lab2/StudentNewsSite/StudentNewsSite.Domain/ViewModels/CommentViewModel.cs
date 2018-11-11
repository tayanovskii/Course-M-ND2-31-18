using System;

namespace StudentNewsSite.Domain.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual StudentViewModel Author { get; set; }
        public virtual DateTime Created { get; set; }
        public int PostId { get; set; }
        public virtual PostViewModel Post { get; set; }

    }
}
