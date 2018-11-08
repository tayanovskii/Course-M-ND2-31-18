using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Services;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;

        public PostController(PostService post)
        {
            this.postService = post;
        }

        // GET: Post
        public ActionResult Index(StudentViewModel currentStudent)
        {
            var modelTuple = new Tuple<StudentViewModel, IEnumerable<PostViewModel>>(currentStudent, postService.GetAllPosts());
            return View(modelTuple);
        }

        public ActionResult Create(StudentViewModel currentStudent, PostViewModel postViewModel)
        {
            postViewModel.Author= currentStudent;
            return View(postViewModel);
        }
        [HttpPost]
        public ActionResult Create(PostViewModel postViewModel)
        {
            postService.Create(postViewModel);
            return RedirectToAction("Index", "Post", postViewModel.Author);
        }

        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}