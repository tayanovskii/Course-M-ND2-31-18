using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService post)
        {
            postService = post;
        }

        public ActionResult Index()
        {
            var currentStudent = Session["currentStudent"] as StudentViewModel;
            var modelTuple =
                new Tuple<StudentViewModel, IEnumerable<PostViewModel>>(currentStudent, postService.GetAllPosts());
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

        //public ActionResult Edit(int id)
        //{
        //    var postViewModel = postService.Get(id);
        //    return View(postViewModel);
        //}

        //[HttpPost]
        //public ActionResult Edit(PostViewModel postViewModel)
        //{
        //    postService.Edit(postViewModel);
        //    return RedirectToAction("Index", "Post");
        //}

        public ActionResult Edit(int id)
        {
            var postViewModel = postService.Get(id);
            var createPostViewModel = postService.Get(postViewModel);
            return View(createPostViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CreatePostViewModel createPostViewModel)
        {
            postService.Edit(createPostViewModel);
            return RedirectToAction("Index", "Post");
        }

        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}