using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLyProject.DTOs.RequestsDTO;
using QLyProject.Repositorys.IRepository;
using QLyProject.Respone;
using QLyProject.Services.IService;
using System.Net;

namespace QLyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherServices _teacherServices;
        public CourseController(ICourseService courseService , ITeacherServices teacherServices)
        {
            _courseService = courseService;
            _teacherServices = teacherServices;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("create")]
        public async Task<IActionResult> Create(CourseRequestDTO course)
        {
            try
            {
                var teacher = await _teacherServices.GetTeacher(course.TeacherId);
                if (teacher == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Teacher"
                    });

                }
                else
                {
                    var newCourse = await _courseService.CreateCourse(course);
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Create Course successfully",
                        Result=newCourse
                        
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomRespone
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "Internal Server Error: " + ex.Message
                });
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getcourse/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                var course = await _courseService.GetCourses(id);
                if (course == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Course"
                    });

                }
                else
                {
                 
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Create Course successfully",
                        Result = course

                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomRespone
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "Internal Server Error: " + ex.Message
                });
            }

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var course = await _courseService.GetCourses(id);
                if (course == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Course to delete"
                    });

                }
                else
                {
                    await _courseService.DeleteCourse(id);

                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Delete Course successfully",
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomRespone
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "Internal Server Error: " + ex.Message
                });
            }

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id , CourseRequestDTO u_course)
        {
            try
            {
                var course = await _courseService.GetCourses(id);
                if (course == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Course to update"
                    });

                }
                else
                {
                    var teacher = await _teacherServices.GetTeacher(u_course.TeacherId);
                    if(teacher == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            Message = "Require input info Teacher belong to system"
                        });

                    }
                    else
                    {
                        var updateCourse = await _courseService.UpdateCourse(u_course, id);
                        return StatusCode(StatusCodes.Status200OK, new CustomRespone
                        {
                            StatusCode = HttpStatusCode.OK,
                            Message = "Update course successfully"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CustomRespone
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "Internal Server Error: " + ex.Message
                });
            }

        }

    }
}
