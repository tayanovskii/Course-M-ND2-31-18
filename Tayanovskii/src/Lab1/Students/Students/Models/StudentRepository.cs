using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Students.Models
{
    public class StudentRepository:IStudentRepository
    {
        private static readonly string  PathToTheJsonFile =
        AppDomain.CurrentDomain.GetData("DataDirectory") + @"\Students.json";

        private readonly List<Student> _listStudents;

        public StudentRepository()
        {
            _listStudents =GetListStudentsFromJson();
        }

        public List<Student> GetListStudents()
        {
            return _listStudents;
        }

        public Student GetStudent(int id)
        {
            return _listStudents.First(student => student.Id == id);
        }

        public void Create(Student student)
        {
            student.Id = _listStudents.Count + 1;
            student.CreateDateTime=DateTime.Now;
            _listStudents.Add(student);
            SaveListStudentsToJson();
        }

        public void Delete(int id)
        {
            _listStudents.RemoveAll(student => student.Id == id);
            SaveListStudentsToJson();
        }

        public void Edit(Student student)
        {
            var findStudent = _listStudents.First(s => s.Id == student.Id);
            var index = _listStudents.IndexOf(findStudent);
            if (index != -1)
                _listStudents[index] = new Student(){FirstName = student.FirstName,CreateDateTime = DateTime.Now,LastName = student.LastName,Id = student.Id};
            SaveListStudentsToJson();
        }

        public List<Student> GetListStudentsFromJson()
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            try
            {
                var studentsJson = File.ReadAllText(PathToTheJsonFile);
                return JsonConvert.DeserializeObject<List<Student>>(studentsJson);
            }
            catch(Exception)
            {
                return new List<Student>();
            }
        }

        public void SaveListStudentsToJson()
        {
            if (!System.IO.File.Exists(PathToTheJsonFile)) throw new Exception("Database doesn't exist!!!");
            try
            {
                File.WriteAllText(PathToTheJsonFile, JsonConvert.SerializeObject(_listStudents));
            }
            catch (Exception)
            {
                throw new Exception("Error: Can`t write to the file!!!");
            }
            
        }
    }
}