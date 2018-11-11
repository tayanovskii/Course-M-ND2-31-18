using System.Collections.Generic;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetAllPosts();
        void Create(CreatePostViewModel createPostViewModel);
         PostViewModel Get(int id);
        void Edit(PostViewModel postViewModel);
        void Delete(int id);
        void Dispose();
    }
}