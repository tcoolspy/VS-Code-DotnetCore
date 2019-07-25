using System;

namespace dotnetPartTwo.Api.Models.Dtos
{
    public class CourseDto
    {
        public Guid Id {get;set;}
        public string CourseName {get;set;}
        public string CourseDescription {get;set;}
        public string CourseIdentifier {get;set;}
        public int CourseHours {get;set;}      
        public string Url {get;set;}          
    }
}