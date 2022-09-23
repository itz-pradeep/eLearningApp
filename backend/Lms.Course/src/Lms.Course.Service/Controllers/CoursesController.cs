using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lms.Course.Service.Dtos;
using Lms.Course.Service.Entites;
using Lms.Course.Service.Helpers;
using Lms.Course.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Course.Service.Controllers{

    [ApiController]
    [Route("api/v1.0/lms/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseRepository courseRepository = new();
        public CoursesController()
        {

        }

        [HttpGet("getall")]
        public async Task<ActionResult<IReadOnlyCollection<CourseDto>>> GetAll(){
            var courses = (await courseRepository.GetAllAsync())
                            .Select(x=>x.AsDto());
            return Ok(courses);
        }

        [HttpGet("getall/info/{technology}")]
        public ActionResult GetAllByTech([Required]string technology){
            return Ok();
        }

        [HttpGet("get")]
        public ActionResult GetByFilter([FromQuery] CourseRequestFilter filter){
            return Ok();
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCourse([FromBody] CourseCreateDto request){
            var courseToCreate = new TbCourse
            {
                Name = request.Name,
                Hours = request.Hours,
                Minutes = request.Minutes,
                CreatedDate = DateTimeOffset.UtcNow,
                Description = request.Description,
                IsActive = true,
                LaunchUrl = request.LaunchUrl,
                Technology = request.Technology,
            };

            await courseRepository.CreateAsync(courseToCreate);

            return Ok();
        }

        [HttpDelete("delete/{coursename}")]
        public ActionResult DeleteCourse(string CourseName){
            return Ok();
        }

       

    }

}