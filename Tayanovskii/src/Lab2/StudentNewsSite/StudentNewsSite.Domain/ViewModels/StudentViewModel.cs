using System.Collections.Generic;


namespace StudentNewsSite.Domain.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IEnumerable<PostViewModel> Posts { get; set; }
        public virtual IEnumerable<CommentViewModel> Comments { get; set; }


    }
}