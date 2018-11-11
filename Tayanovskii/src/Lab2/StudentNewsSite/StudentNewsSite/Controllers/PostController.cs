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
        public ActionResult Index()
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            var modelTuple = new Tuple<StudentViewModel, IEnumerable<PostViewModel>>(currentStudent, postService.GetAllPosts());
            return View(modelTuple);
        }

        public ActionResult Create()
        {
            return View(new CreatePostViewModel());
        }
        [HttpPost]
        public ActionResult Create(CreatePostViewModel createPostViewModel)
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            createPostViewModel.AuthorId = currentStudent.Id;
            postService.Create(createPostViewModel);
            return RedirectToAction("Index", "Post", currentStudent);

        }

        public ActionResult Delete(int id)
        {
            postService.Delete(id);
            return RedirectToAction("Index", "Post");

        }

        public ActionResult Read(int id)
        {
            var postViewModel = postService.Get(id);
            return View(postViewModel);
        }

        public ActionResult Edit(PostViewModel postViewModel)
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            postService.Edit(postViewModel);
            return RedirectToAction("Index", "Post", currentStudent);

        }
        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}