namespace dotnetPartTwo.Api.Models.Dtos.RequestDtos
{
    public class CourseInputDto
    {
        public string CourseName {get;set;}
        public string CourseDescription {get;set;}
        public string CourseIdentifier {get;set;}
        public int CourseHours {get;set;}        
    }
}