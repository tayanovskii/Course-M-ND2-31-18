using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Services;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class StudentController : Controller
    {
        private StudentService studentService;
       

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(StudentViewModel studentViewModel)
        {
            if(studentService.CheckStudent(studentViewModel)) return RedirectToAction("Index","Post", studentViewModel);
            ViewBag.Message = "Student is not registered in this service";
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(StudentViewModel studentViewModel)
        {
            studentService.CreateStudent(studentViewModel);
            return RedirectToAction("Index", "Post", studentViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            studentService.Dispose();
            base.Dispose(disposing);
        }
    }
}