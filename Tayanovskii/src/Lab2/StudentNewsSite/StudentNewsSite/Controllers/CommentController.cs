﻿using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public ActionResult Create(int id)
        {
            var commentViewModel = new CommentViewModel();
            commentViewModel.PostId = id;
            return View(commentViewModel);
        }
        [HttpPost]
        public ActionResult Create(CommentViewModel commentViewModel)
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            try
            {
                commentViewModel.AuthorId = currentStudent.Id;
                commentService.Create(commentViewModel);
                return RedirectToAction("Read", "Post", new {id = commentViewModel.PostId});
            }
            catch
            {
                return View(commentViewModel);
            }
        }
    }
}