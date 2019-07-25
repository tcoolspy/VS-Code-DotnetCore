using System;

namespace dotnetPartTwo.Api.Models.Dtos
{
    public class StudentCourseDto
    {
        public Guid Id {get;set;}
        public Guid StudentId {get;set;}
        public Guid CourseId {get;set;}
        public decimal? Grade {get;set;}
        public DateTime? CourseStartDate {get;set;}
        public DateTime? CourseEndDate {get;set;} 
        public string Url {get;set;}           
    }
}