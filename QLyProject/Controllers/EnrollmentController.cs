
using Microsoft.AspNetCore.Mvc;

using QLyProject.DTOs.RequestsDTO;
using QLyProject.DTOs.ResponesDTO;

using QLyProject.Respone;
using QLyProject.Services.IService;
using System.Net;

namespace QLyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        public EnrollmentController(IEnrollmentService enrollmentService, IUserService userService, ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _userService = userService;
            _courseService = courseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("create")]
        public async Task<IActionResult> Create(EnrollmentRequestDTO enrollment)
        {
            try
            {
                var user = await _userService.GetUser(enrollment.UserId);
                var course = await _courseService.GetCourses(enrollment.CourseID);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info User to system"
                    });

                }
                else if (course == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Course to system"
                    });
                }
                else
                {
                    var c_enrollment = await _enrollmentService.CreateEnrrollment(enrollment);
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Create enrollment successfully",
                        Result = c_enrollment

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
                var d_enrollment = await _enrollmentService.GetEnrollments(id);
                if (d_enrollment == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Enrollment to system"
                    });

                }
                else
                {
                    await _enrollmentService.DeleteEnrollment(id);
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Create enrollment successfully",
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
        [Route("getenrollment/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var g_enrollment = await _enrollmentService.GetEnrollments(id);
                if (g_enrollment == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Enrollment to system"
                    });

                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Result = new EnrollResponeDTO
                        {
                            UserId = g_enrollment.UserId,
                            CoursesID = g_enrollment.CoursesID,
                            Classroom = g_enrollment.Classroom
                        }
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
        public async Task<IActionResult> Update(int id , EnrollmentRequestDTO enroll)
        {
            try
            {
                var u_enrollment = await _enrollmentService.GetEnrollments(id);
                if (u_enrollment == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not info Enrollment to system"
                    });

                }
                else
                {
                    var n_enrollment = await _enrollmentService.UpdateEnrrollment(enroll, id);
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                            Result = new EnrollResponeDTO
                        {
                            UserId = n_enrollment.UserId,
                            CoursesID = n_enrollment.CoursesID,
                            Classroom = n_enrollment.Classroom
                        }
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
    }
}
