using System;
using System.Linq;
using dotnetPartTwo.Api.Models.Dtos.RequestDtos;
using dotnetPartTwo.Core.Contracts;
using dotnetPartTwo.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartTwo.Api.Controllers
{    
    public class CourseApiController : BaseApiController
    {
        private readonly IGenericRepository<Course, Guid> _courseRepository;

        public CourseApiController(LinkGenerator linkGenerator, 
                                   IGenericRepository<Course, Guid> courseRepository) : base(linkGenerator)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException("courseRepository");
        }

        [HttpGet]
        [Route("api/course/{id}")]
        public IActionResult Get(string id)
        {
            Guid courseId;
            if (Guid.TryParse(id, out courseId))
            {                
                var response = _courseRepository.Get(courseId);
                var course = TheModelFactory.Create(response);
                return Ok(course);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/course")]
        public IActionResult GetAll()
        {
            var response = _courseRepository.GetAll();
            var courses = response.Select(x => TheModelFactory.Create(x));
            return Ok(courses);
        }

        [HttpGet]
        [Route("api/course/filter")]
        public IActionResult GetFiltered()        
        {
            var queryParams = this.HttpContext.Request.Query.ToList();
            if (queryParams.Any())
            {                
                var param = queryParams.Single().Value.ToString();
                var key = this.HttpContext.Request.Query.Keys.ToList().Single();
                switch (key)
                {
                    case "courseName":
                        var nameResponse = _courseRepository.GetAll(x => x.CourseName.ToLower().Contains(param.ToLower()));
                        var nameCourses = nameResponse.Select(x => TheModelFactory.Create(x));                    
                        return Ok(nameCourses);                      
                    case "courseDescription":
                        var descriptionResponse = _courseRepository.GetAll(x => x.CourseDescription.ToLower().Contains(param.ToLower()));
                        var descriptionCourses = descriptionResponse.Select(x => TheModelFactory.Create(x));                    
                        return Ok(descriptionCourses);     
                    case "courseId":
                        var idResponse = _courseRepository.GetAll(x => x.CourseIdentifier.ToLower().Contains(param.ToLower()));
                        var idCourses = idResponse.Select(x => TheModelFactory.Create(x));
                        return Ok(idCourses);                                 
                }          
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/course")]
        public IActionResult Add([FromBody] CourseInputDto courseInputDto)
        {
            var newCourse = new Course
            {
                Id = Guid.NewGuid(),
                CourseDescription = courseInputDto.CourseDescription,
                CourseHours = courseInputDto.CourseHours,
                CourseIdentifier = courseInputDto.CourseIdentifier,
                CourseName = courseInputDto.CourseName
            };

            var response = _courseRepository.Add(newCourse);
            if (response.Success) return CreatedAtAction(nameof(Get), new { id = newCourse.Id}, newCourse);
            return StatusCode(500, response.Message);
        }

        [HttpPatch]
        [Route("api/course")]
        public IActionResult Update([FromBody] CourseUpdateDto courseUpdateDto)
        {
            Guid courseId;
            if (Guid.TryParse(courseUpdateDto.Id, out courseId))
            {
                var courseToUpdate = _courseRepository.Get(courseId);
                if (courseToUpdate == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(courseUpdateDto.CourseDescription)) 
                    courseToUpdate.CourseDescription = courseUpdateDto.CourseDescription;
                if (!string.IsNullOrEmpty(courseUpdateDto.CourseIdentifier))
                    courseToUpdate.CourseIdentifier = courseUpdateDto.CourseIdentifier;
                if (!string.IsNullOrEmpty(courseUpdateDto.CourseName))
                    courseToUpdate.CourseName = courseUpdateDto.CourseName;
                int hours;
                if (Int32.TryParse(courseUpdateDto.CourseHours, out hours))
                {
                    courseToUpdate.CourseHours = Convert.ToInt32(courseUpdateDto.CourseHours);
                }

                var response = _courseRepository.Update(courseToUpdate);
                if (response.Success) 
                    return Ok($"Course with id {courseId} was successfully updated.");
                else return StatusCode(500, response.Message);
            }
            else return NotFound();
        }

        [HttpDelete]
        [Route("api/course/{id}")]
        public IActionResult Delete(string id)
        {
            Guid courseId;
            if (Guid.TryParse(id, out courseId))
            {
                var courseToDelete = _courseRepository.Get(courseId);
                if (courseToDelete == null)
                {
                    return NotFound();
                }

                var response = _courseRepository.Delete(courseToDelete);
                if (response.Success)
                    return Ok($"Course with id {courseId} was successfully deleted.");
                else return StatusCode(500, response.Message);
            }
            return Ok();
        }        
    }
}