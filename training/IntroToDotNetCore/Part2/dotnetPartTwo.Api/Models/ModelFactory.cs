using dotnetPartTwo.Api.Models.Dtos;
using dotnetPartTwo.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartTwo.Api.Models
{
    public class ModelFactory
    {
        protected LinkGenerator _linkGenerator;
        protected ActionContext _context;
        private string _baseUrl;
        public ModelFactory()
        {}

        public ModelFactory(ActionContext context, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _context = context;
            _baseUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.PathBase}";
        }

        public CourseDto Create(Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                CourseDescription = course.CourseDescription,
                CourseHours = course.CourseHours,
                CourseIdentifier = course.CourseIdentifier,
                CourseName = course.CourseName,
                Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "CourseApi", action: "Get", values: new { id = course.Id})
            };
        }

        public StudentDto Create(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName ,
                Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "StudentApi", action: "Get", values: new { id = student.Id})
            };
        }

        public StudentCourseDto Create(StudentCourse studentCourse)
        {
            return new StudentCourseDto
            {
                Id = studentCourse.Id,
                CourseEndDate = studentCourse.EndDate,
                CourseId = studentCourse.CourseId,
                CourseStartDate = studentCourse.StartDate,
                Grade = studentCourse.Grade,
                StudentId = studentCourse.StudentId,
                Url = _linkGenerator.GetPathByAction(_context.HttpContext, controller: "StudentCourseApi", action: "Get", values: new { id = studentCourse.Id})
            };
        }        
    }
}