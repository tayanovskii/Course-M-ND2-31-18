﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Domain.Contracts.Models;

namespace Twitter.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPostsAsync();
        Task<IEnumerable<PostViewModel>> GetLastPostsAsync(int count);
        Task CreateAsync(PostViewModel postViewModel);
        Task<PostViewModel> GetAsync(int id);
        Task EditAsync(PostViewModel postViewModel);
        Task DeleteAsync(int id);
        void Dispose();
    }
}