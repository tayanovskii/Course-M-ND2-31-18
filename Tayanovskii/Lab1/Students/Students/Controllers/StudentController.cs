using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Students.Models;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository = new StudentRepository();
        // GET
        public ActionResult Index()
        {
           
            return View(_studentRepository.GetListStudents());
        }

        [HttpPost]
        public ActionResult Create(Student createStudent)
        {
           
            _studentRepository.Create(createStudent);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
          
            return View(_studentRepository.GetStudent(id));
             
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            _studentRepository.Edit(student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            
           _studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}