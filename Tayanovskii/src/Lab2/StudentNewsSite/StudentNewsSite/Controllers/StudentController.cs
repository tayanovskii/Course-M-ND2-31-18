using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;
       

        public StudentController(IStudentService studentService)
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
            var currentStudentViewModel = studentService.Get(studentViewModel);
            if (currentStudentViewModel != null)
            {
                this.Session["currentStudent"] = currentStudentViewModel;
                return RedirectToAction("Index","Post");
            }
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
            var currentStudentViewModel = studentService.Get(studentViewModel);
            if (currentStudentViewModel == null)
            {
                var idStudent = studentService.Create(studentViewModel);
                var currentStudent = studentService.Get(idStudent);
                this.Session["currentStudent"] = currentStudent;
                return RedirectToAction("Index", "Post");
            }
            ViewBag.Message = "This student registered in service yet";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            studentService.Dispose();
            base.Dispose(disposing);
        }
    }
}