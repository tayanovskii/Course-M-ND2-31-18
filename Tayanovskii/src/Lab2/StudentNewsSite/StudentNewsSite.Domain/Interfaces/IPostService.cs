using System.Collections.Generic;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetAllPosts();
        void Create(PostViewModel postViewModel);
        void Dispose();
    }
}