using System;

namespace dotnetPartTwo.Core.Models
{
    public class StudentCourse
    {
        public Guid Id {get;set;}
        public Guid StudentId {get;set;}
        public Guid CourseId {get;set;}
        public decimal? Grade {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}

        public Student Student {get;set;}
        public Course Course {get;set;}
    }
}