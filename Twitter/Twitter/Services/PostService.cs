using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Twitter.Data;
using Twitter.Data.Entities;
using Twitter.Data.Repositories;
using Twitter.Models;
using Twitter.Repositories;

namespace Twitter.Services
{
    public class PostService:IPostService
    {

        private readonly IMapper mapper;
        private readonly IRepository<Post> postRepository;

        public PostService(IMapper mapper, IRepository<Post> postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPosts()
        {
            var allPosts = await postRepository.GetAllAsync();
            var postViewModels = mapper.Map<IEnumerable<PostViewModel>>(allPosts);
            return postViewModels;
        }

        public async Task<IEnumerable<PostViewModel>> GetLastPostsAsync(int count)
        {
            var lastPosts = await postRepository.GetLastAsync(20);
            var postViewModels = mapper.Map<IEnumerable<PostViewModel>>(lastPosts);
            return postViewModels;
        }

        public async Task Create(PostViewModel postViewModel)
        {
            postViewModel.CreatedTime = DateTime.Now;
            var post = mapper.Map<Post>(postViewModel);
            await postRepository.CreateAsync(post);
        }

        public async Task<PostViewModel> Get(int id)
        {
            var post = await postRepository.GetByIdAsync(id);
            var postViewModel = mapper.Map<PostViewModel>(post);
            return postViewModel;
        }

        public async Task Edit(PostViewModel postViewModel)
        {
            var editPost = await postRepository.GetByIdAsync(postViewModel.Id);
            editPost.Content = postViewModel.Content;
            await postRepository.UpdateAsync(editPost);
        }

        public async Task Delete(int id)
        {
            await postRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            postRepository.Dispose();
        }
    }
}