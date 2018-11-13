using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ninject.Infrastructure.Language;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class PostService:IPostService
    {
        private IUnitOfWork UnitOfWork { get;}
        private IMapper Mapper { get; }

        public PostService(IUnitOfWork iOfWork, IMapper mapper)
        {
            UnitOfWork = iOfWork;
            Mapper = mapper;
        }
        public IEnumerable<PostViewModel> GetAllPosts()
        {
            var postViewModels = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(UnitOfWork.Posts.GetAll());
            return postViewModels;
        }
        public void Create(CreatePostViewModel createPostViewModel)
        {
            var tags = createPostViewModel.Tags.Split(new []{','},options: StringSplitOptions.RemoveEmptyEntries);
            var newPostViewModel = new PostViewModel
            {
                AuthorId = createPostViewModel.AuthorId,
                Created = DateTime.Now,
                Content = createPostViewModel.Content,
                Tags = new List<TagViewModel>()
            };
            foreach (var tag in tags)
            {
                newPostViewModel.Tags.Add(new TagViewModel { Name = tag.Trim() });
            }
            var newPostEntity = Mapper.Map<PostViewModel, Post>(source: newPostViewModel);
            UnitOfWork.Posts.Create(newPostEntity);
            UnitOfWork.Save();
        }
        public PostViewModel Get(int id)
        {
            var post = UnitOfWork.Posts.Get(id);
            var postViewModel = Mapper.Map<Post, PostViewModel>(post);
            return postViewModel;
        }
        public CreatePostViewModel Get(PostViewModel postViewModel)
        {
            var listTags = postViewModel.Tags.Select(model => model.Name);
            var tagsString = string.Join(",", listTags);
            var createPostViewModel = Mapper.Map<PostViewModel,CreatePostViewModel>(postViewModel);
            createPostViewModel.Tags = tagsString;
            return createPostViewModel;
        }
        public void Edit(CreatePostViewModel createPostViewModel)
        {
            var editPost = UnitOfWork.Posts.Get(createPostViewModel.Id);
            editPost.Content = createPostViewModel.Content;
            var tags = createPostViewModel.Tags.Split(new[] { ',' }, options: StringSplitOptions.RemoveEmptyEntries);
            foreach (var tag in tags)
            {
                if (editPost.Tags.Any(t => t.Name == tag.Trim())) continue;
                var newTag = new Tag() { Name= tag.Trim()};
                UnitOfWork.Tags.Create(newTag);
                editPost.Tags.Add(newTag);
            }

            UnitOfWork.Posts.Update(editPost);
            UnitOfWork.Save();
        }
        public void Delete(int id)
        {
            UnitOfWork.Posts.Delete(id);
            UnitOfWork.Save();
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}