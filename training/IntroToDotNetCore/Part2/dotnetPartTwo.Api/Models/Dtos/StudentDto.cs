using System;

namespace dotnetPartTwo.Api.Models.Dtos
{
    public class StudentDto
    {
        public Guid Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}    
        public string Url {get;set;}           
    }
}