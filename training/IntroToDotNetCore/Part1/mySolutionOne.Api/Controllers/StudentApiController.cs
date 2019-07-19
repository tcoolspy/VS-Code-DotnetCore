using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mySolutionOne.Api.Data;
using mySolutionOne.Api.Models.Dtos;
using mySolutionOne.Core.Models;

namespace mySolutionOne.Api.Controllers
{
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private StudentContext _studentContext;

        public StudentApiController(StudentContext studentContext)
        {
            _studentContext = studentContext ?? throw new ArgumentNullException("studentContext");
        }


        [HttpGet]
        [Route("api/student/{id}")]
        public IActionResult Get(string id)
        {
            var studentId = Guid.Parse(id);
            var student = _studentContext.Students.Find(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("api/student")]
        public IActionResult GetAll()
        {
            var students = _studentContext.Students.ToList();
            return Ok(students);
        }

        [HttpPost]
        [Route("api/student")]
        public IActionResult Add([FromBody] StudentInputDto studentInfo)
        {
            var newStudent = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = studentInfo.FirstName,
                LastName = studentInfo.LastName,
                Email = studentInfo.Email
            };

            _studentContext.Add(newStudent);
            _studentContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newStudent.Id}, newStudent);
        }

        [HttpPatch]
        [Route("api/student")]
        public IActionResult Update([FromBody] StudentUpdateDto studentInfo)
        {
            var studentId = Guid.Parse(studentInfo.Id);
            var studentToUpdate = _studentContext.Students.Find(studentId);
            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(studentInfo.FirstName)) studentToUpdate.FirstName = studentInfo.FirstName;
            if (!string.IsNullOrEmpty(studentInfo.LastName)) studentToUpdate.LastName = studentInfo.LastName;
            if (!string.IsNullOrEmpty(studentInfo.Email)) studentToUpdate.Email = studentInfo.Email;

            _studentContext.Students.Update(studentToUpdate);
            _studentContext.SaveChanges();
            return Ok($"Student with id {studentId} was successfully updated.");
        }

        [HttpDelete]
        [Route("api/student")]
        public IActionResult Delete([FromBody] StudentUpdateDto studentInfo)        
        {
            var studentId = Guid.Parse(studentInfo.Id);
            var student = _studentContext.Students.Find(studentId);
            if (student == null)
            {
                return NotFound();
            }

            _studentContext.Students.Remove(student);
            _studentContext.SaveChanges();
            return Ok($"student with id {studentId} was successfully removed from the database.");
        }
    }
}