using System;
using System.Collections.Generic;

namespace dotnetPartTwo.Core.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<StudentCourse>();
        }
        public Guid Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}       

        public virtual IEnumerable<StudentCourse> Courses {get;set;} 
    }
}