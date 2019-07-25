using System;
using System.Linq;
using dotnetPartTwo.Core.Contracts;
using dotnetPartTwo.Core.Models;

namespace dotnetPartTwo.Business.Contracts
{
    public interface IStudentService: IGenericBusinessService<Student, Guid>
    {
         IQueryable<Student> GetStudentsWithLastNameStartsWith(string filter);
    }
}