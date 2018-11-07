using System;

namespace StudentNewsSite.Domain.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public StudentViewModel Author { get; set; }
        public DateTime Created { get; set; }
        public PostViewModel Post { get; set; }

    }
}
