using System;
using System.Linq;
using dotnetPartTwo.Business.Contracts;
using dotnetPartTwo.Core.Contracts;
using dotnetPartTwo.Core.Models;

namespace dotnetPartTwo.Business.Services
{
    public class StudentService : GenericBusinessService<Student, Guid>, IStudentService
    {
        public StudentService(IGenericRepository<Student, Guid> dataRepository) : base(dataRepository)
        {
        }

        public IQueryable<Student> GetStudentsWithLastNameStartsWith(string filter)
        {
            var students = DataRepository.GetAll(x => x.LastName.ToLower().StartsWith(filter.ToLower()));
            return students;            
        }        
    }
}