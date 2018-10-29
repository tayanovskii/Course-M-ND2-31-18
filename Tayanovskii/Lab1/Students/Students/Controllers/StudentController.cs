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
        public static readonly string PathToTheJsonFile =
            AppDomain.CurrentDomain.GetData("DataDirectory") + @"\Students.json";

        // GET
        public ActionResult Index()
        {
            var students = new List<Student>();
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            using (var file = System.IO.File.OpenText(PathToTheJsonFile))
            using (var reader = new JsonTextReader(file))
            {
                try
                {
                    var studentJArray = (JArray) JToken.ReadFrom(reader);
                    students = studentJArray.ToObject<List<Student>>();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return View(students);
        }

        [HttpPost]
        public ActionResult Create(Student createStudent)
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            var listStudents = new List<Student>();
            JArray studentJArray;
            using (var file = System.IO.File.OpenText(PathToTheJsonFile))
            using (var reader = new JsonTextReader(file))
            {
                try
                {
                    studentJArray = (JArray) JToken.ReadFrom(reader);
                    studentJArray.Add(JToken.FromObject(new Student(studentJArray.Count + 1, createStudent.FirstName,
                        createStudent.LastName, DateTime.Now)));
                }
                catch (Exception)
                {
                    listStudents.Add(new Student(1, createStudent.FirstName, createStudent.LastName, DateTime.Now));
                    studentJArray = (JArray) JToken.FromObject(listStudents);
                }
            }

            using (var file = System.IO.File.CreateText(PathToTheJsonFile))
            using (var writer = new JsonTextWriter(file))
            {
                studentJArray.WriteTo(writer);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            using (var file = System.IO.File.OpenText(PathToTheJsonFile))
            using (var reader = new JsonTextReader(file))
            {
                try
                {
                    var studentJArray = JToken.ReadFrom(reader);
                    var students = studentJArray.ToObject<List<Student>>();
                    var selectedUser = students.Single(student => student.Id == id);
                    return View(selectedUser);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            JArray studentJArray = null;
            using (var file = System.IO.File.OpenText(PathToTheJsonFile))
            using (var reader = new JsonTextReader(file))
            {
                try
                {
                    studentJArray = (JArray) JToken.ReadFrom(reader);
                    var students = studentJArray.ToObject<List<Student>>();
                    var findStudent = students.First(s => s.Id == student.Id);
                    var index = students.IndexOf(findStudent);
                    if (index != -1)
                        students[index] = new Student(student.Id, student.FirstName, student.LastName, DateTime.Now);
                    studentJArray = (JArray) JToken.FromObject(students);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            using (var file = System.IO.File.CreateText(PathToTheJsonFile))
            using (var writer = new JsonTextWriter(file))
            {
                studentJArray?.WriteTo(writer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            JArray studentJArray = null;
            using (var file = System.IO.File.OpenText(PathToTheJsonFile))
            using (var reader = new JsonTextReader(file))
            {
                try
                {
                    studentJArray = (JArray) JToken.ReadFrom(reader);
                    var students = studentJArray.ToObject<List<Student>>();
                    students.RemoveAll(s => s.Id == id);
                    studentJArray = (JArray) JToken.FromObject(students);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            using (var file = System.IO.File.CreateText(PathToTheJsonFile))
            using (var writer = new JsonTextWriter(file))
            {
                studentJArray?.WriteTo(writer);
            }
            return RedirectToAction("Index");
        }
    }
}