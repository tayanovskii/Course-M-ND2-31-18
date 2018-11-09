using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService post)
        {
            this.postService = post;
        }

        // GET: Post
        public ActionResult Index(StudentViewModel currentStudent)
        {
            this.Session["currentStudent"] = currentStudent;
            var modelTuple = new Tuple<StudentViewModel, IEnumerable<PostViewModel>>(currentStudent, postService.GetAllPosts());
            return View(modelTuple);
        }

        public ActionResult Create(StudentViewModel currentStudent)
        {
            return View(new PostViewModel());
        }
        [HttpPost]
        public ActionResult Create(PostViewModel postViewModel)
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            postViewModel.Author = currentStudent;
            postService.Create(postViewModel);
            //this.Session["currentStudent"] = null;
            return RedirectToAction("Index", "Post", currentStudent);
        }

        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}