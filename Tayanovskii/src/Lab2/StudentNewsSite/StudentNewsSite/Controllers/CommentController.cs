using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: Comment/Create
        public ActionResult Create(int id)
        {
            var commentViewModel = new CommentViewModel();
            commentViewModel.PostId = id;
            return View(commentViewModel);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentViewModel commentViewModel)
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            try
            {
                commentViewModel.AuthorId = currentStudent.Id;
                commentService.Create(commentViewModel);
                return RedirectToAction("Read","Post", new {id = commentViewModel.PostId});
            }
            catch
            {
                return View(commentViewModel);
            }
        }
        

    }
}
