using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class TagController : Controller
    {
        private ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        // GET: Tag
        public ActionResult Create()
        {
            return View(new TagViewModel());
        }
        [HttpPost]
        public ActionResult Create(TagViewModel tagViewModel)
        {
            var newTagViewModel = new TagViewModel {Name = tagViewModel.Name};
            return RedirectToAction("Create", "Post", newTagViewModel);
        }
    }
}