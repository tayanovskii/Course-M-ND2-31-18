using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.DAL.Contexts;

namespace StudentNewsSite.Data.Repositories
{
    public class StudentRepository:IRepository<Student>
    {
        private readonly StudentNewsSiteContext dbContext;

        public StudentRepository(StudentNewsSiteContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Student> GetAll()
        {
            return dbContext.Students;
        }
        public Student Get(int id)
        {
            return dbContext.Students.Find(id);
        }
        public void Create(Student student)
        {
            dbContext.Students.Add(student);
        }
        public void Update(Student student)
        {
            dbContext.Entry(student).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var deleteStudent = dbContext.Students.Find(id);
            if (deleteStudent != null) dbContext.Students.Remove(deleteStudent);
        }
        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return dbContext.Students.Where(predicate);
        }

    }
}