using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.DAL.EF;
using StudentNewsSite.DAL.Entities;

namespace StudentNewsSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            var studentNewsSiteContext = new StudentNewsSiteContext();
            studentNewsSiteContext.Students.Add(new Student() {Comments = null, Id = 1, Posts = null, FirstName = "Petr", LastName = "Petrov"});
            studentNewsSiteContext.SaveChanges();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}