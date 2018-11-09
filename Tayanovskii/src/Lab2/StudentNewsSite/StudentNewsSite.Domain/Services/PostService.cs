using System;
using System.Collections.Generic;
using AutoMapper;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class PostService:IPostService
    {
        private IUnitOfWork UnitOfWork { get;}

        public PostService(IUnitOfWork iOfWork)
        {
            this.UnitOfWork = iOfWork;
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostViewModel>().ForMember(dest=>dest.Id,opt=>opt.MapFrom(source=>source.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(source => source.Content))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(source => source.Author))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(source => source.Comments))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(source => source.Tags)));
            var mapper = mapperConfiguration.CreateMapper();
            var postViewModels = mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(UnitOfWork.Posts.GetAll());
            return postViewModels;
        }

        public void Create(PostViewModel postViewModel)
        {
            postViewModel.Created=DateTime.Now;
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<PostViewModel, Post>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(source => source.Content))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(source => source.Author))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(source => source.Comments))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(source => source.Tags)));
            var post = mapperConfiguration.CreateMapper().Map<PostViewModel, Post>(postViewModel);
            UnitOfWork.Posts.Create(post);
            UnitOfWork.Save();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}