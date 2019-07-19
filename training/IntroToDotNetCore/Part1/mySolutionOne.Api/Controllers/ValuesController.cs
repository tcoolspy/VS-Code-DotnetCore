using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySolutionOne.Api.Data;
using mySolutionOne.Core.Models;

namespace mySolutionOne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StudentContext _studentContext;
        public ValuesController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var studentList = new List<Student>();
            studentList.Add(new Student { Id = Guid.NewGuid(), FirstName = "Tony", LastName = "Stark", Email = "tstark@abc.com"});
            studentList.Add(new Student { Id = Guid.NewGuid(), FirstName = "Bruce", LastName = "Banner", Email = "bbanner@abc.com"});
            studentList.Add(new Student { Id = Guid.NewGuid(), FirstName = "Natasha", LastName = "Romanov", Email = "nromanov@abc.com"});
            studentList.Add(new Student { Id = Guid.NewGuid(), FirstName = "Steve", LastName = "Rogers", Email = "srogers@abc.com"});
            var students = new List<string>();
            foreach (var student in studentList)
            {
                students.Add($"{student.FirstName} {student.LastName} ({student.Email}: {student.Id})");
            }
            return students.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
