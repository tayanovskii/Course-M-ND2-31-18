using System;
using AutoMapper;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class CommentService:ICommentService
    {

        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public void Create(CommentViewModel commentViewModel)
        {
            commentViewModel.Created=DateTime.Now;
            var newComment = Mapper.Map<CommentViewModel, Comment>(commentViewModel);
            UnitOfWork.Comments.Create(newComment);
            UnitOfWork.Save();
        }
        public CommentViewModel Get(int id)
        {
            var comment = UnitOfWork.Comments.Get(id);
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(comment);
            return commentViewModel;
        }
    }
}