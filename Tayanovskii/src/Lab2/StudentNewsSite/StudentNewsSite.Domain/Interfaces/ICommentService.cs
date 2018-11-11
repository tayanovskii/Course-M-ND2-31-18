using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentViewModel commentViewModel);
        CommentViewModel Get(int id);
    }
}