using System;

namespace Lms.Course.Service.Dtos
{
    public record CourseDto(Guid Id,string Name,int Hours
    , int Minutes,string Description, string Technology,string LaunchUrl,DateTimeOffset ModifiedDate);

    public record CourseCreateDto(string Name,int Hours
    , int Minutes,string Description, string Technology,string LaunchUrl,DateTimeOffset ModifiedDate);

}