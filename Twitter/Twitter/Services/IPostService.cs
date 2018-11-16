using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPosts();
        Task<IEnumerable<PostViewModel>> GetLastPostsAsync(int count);
        Task Create(PostViewModel postViewModel);
        Task<PostViewModel> Get(int id);
        Task Edit(PostViewModel postViewModel);
        Task Delete(int id);
        void Dispose();
    }
}