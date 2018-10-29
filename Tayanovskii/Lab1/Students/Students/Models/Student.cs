using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Students.Models
{
    [DisplayName("Student")]
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDateTime { get; set;}

        public Student()
        {

        }
        public Student(int id, string firstName, string lastName, DateTime dateTime)
        {
            CreateDateTime = dateTime;
            FirstName = firstName;
            Id = id;
            LastName = lastName;
        }
    }
}