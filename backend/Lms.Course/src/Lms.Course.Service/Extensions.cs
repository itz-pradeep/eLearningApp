using Lms.Course.Service.Dtos;
using Lms.Course.Service.Entites;

namespace Lms.Course.Service{
   public static class Extension{
        public static CourseDto AsDto(this TbCourse tbCourse){
        return new CourseDto(tbCourse.Id,tbCourse.Name,tbCourse.Hours,tbCourse.Minutes
        ,tbCourse.Description,tbCourse.Technology,tbCourse.LaunchUrl,tbCourse.CreatedDate);
    }
  
   }
}