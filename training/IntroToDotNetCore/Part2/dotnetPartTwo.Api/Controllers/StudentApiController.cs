using System;
using System.Linq;
using dotnetPartTwo.Api.Models.Dtos.RequestDtos;
using dotnetPartTwo.Core.Contracts;
using dotnetPartTwo.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartTwo.Api.Controllers
{
    public class StudentApiController : BaseApiController
    {
        private readonly IGenericRepository<Student, Guid> _studentRepository;
        public StudentApiController(LinkGenerator linkGenerator,
                                    IGenericRepository<Student, Guid> studentRepository) : base(linkGenerator)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException("studentRepository");
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public IActionResult Get(string id)
        {
            Guid studentId;
            if (Guid.TryParse(id, out studentId))
            {
                var response = _studentRepository.Get(studentId);
                if (response == null)
                {
                    return NotFound();
                }
                var student = TheModelFactory.Create(response);
                return Ok(student);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/student")]
        public IActionResult GetAll()
        {
            var response = _studentRepository.GetAll();
            var students = response.Select(x => TheModelFactory.Create(x));
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

            var response = _studentRepository.Add(newStudent);
            if (response.Success)
            {
                return CreatedAtAction(nameof(Get), new { id = newStudent.Id}, newStudent);
            }
            return StatusCode(500, response.Message);
        }

        [HttpPatch]
        [Route("api/student")]
        public IActionResult Update([FromBody] StudentUpdateDto studentInfo)
        {
            Guid studentId;
            if (Guid.TryParse(studentInfo.Id, out studentId))
            {
                var studentToUpdate = _studentRepository.Get(studentId);
                if (studentToUpdate == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(studentInfo.FirstName)) studentToUpdate.FirstName = studentInfo.FirstName;
                if (!string.IsNullOrEmpty(studentInfo.LastName)) studentToUpdate.LastName = studentInfo.LastName;
                if (!string.IsNullOrEmpty(studentInfo.Email)) studentToUpdate.Email = studentInfo.Email;

                var response = _studentRepository.Update(studentToUpdate);
                if (response.Success)
                    return Ok($"Student with id {studentId} was successfully updated.");
                return StatusCode(500, response.Message);                
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public IActionResult Delete(string id)        
        {
            Guid studentId;
            if (Guid.TryParse(id, out studentId))
            {
                var student = _studentRepository.Get(studentId);
                if (student == null)
                {
                    return NotFound();
                }

                var response = _studentRepository.Delete(student);
                if (response.Success)                    
                    return Ok($"student with id {studentId} was successfully removed from the database.");
                return StatusCode(500, response.Message);
            }
            return NotFound();
        }        
    }
}