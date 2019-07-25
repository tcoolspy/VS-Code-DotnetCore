using System;
using System.Collections.Generic;

namespace dotnetPartTwo.Core.Models
{
    public class Course
    {
        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }

        public Guid Id {get;set;}
        public string CourseName {get;set;}
        public string CourseDescription {get;set;}
        public string CourseIdentifier {get;set;}
        public int CourseHours {get;set;}

        public virtual IEnumerable<StudentCourse> StudentCourses {get;set;}
    }
}