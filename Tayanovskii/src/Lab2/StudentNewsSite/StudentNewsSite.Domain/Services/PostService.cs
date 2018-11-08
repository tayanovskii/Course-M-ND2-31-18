using System;
using System.Collections.Generic;
using AutoMapper;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class PostService
    {
        private IUnitOfWork IUnitOfWork { get; set; }

        public PostService(IUnitOfWork iOfWork)
        {
            this.IUnitOfWork = iOfWork;
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostViewModel>());
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(IUnitOfWork.Posts.GetAll());
        }

        public void Create(PostViewModel postViewModel)
        {
            postViewModel.Created=DateTime.Now;
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<PostViewModel, Post>());
            var post = mapperConfiguration.CreateMapper().Map<PostViewModel, Post>(postViewModel);
            IUnitOfWork.Posts.Create(post);
            IUnitOfWork.Save();
        }

        public void Dispose()
        {
            IUnitOfWork.Dispose();
        }
    }
}