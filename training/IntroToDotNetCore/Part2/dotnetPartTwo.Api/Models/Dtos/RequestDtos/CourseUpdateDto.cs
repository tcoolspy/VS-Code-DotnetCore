namespace dotnetPartTwo.Api.Models.Dtos.RequestDtos
{
    public class CourseUpdateDto
    {
        public string Id {get;set;}
        public string CourseName {get;set;}
        public string CourseDescription {get;set;}
        public string CourseIdentifier {get;set;}
        public string CourseHours {get;set;}          
    }
}