using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLyProject.DTOs.RequestsDTO;
using QLyProject.Respone;
using QLyProject.Services.IService;
using System.Net;
using System.Net.WebSockets;

namespace QLyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServices _teacherServices;
        public TeacherController(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("create")]
        public async Task<IActionResult> Create(TeacherRequestDTO teacher)
        {
            try
            {
                var newTeacher = await _teacherServices.CreateTeacher(teacher);
                return StatusCode(StatusCodes.Status200OK, new CustomRespone
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Create teacher successfully",
                    Result = newTeacher
                });
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("get/{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            try
            {
                var getTeacher = await _teacherServices.GetTeacher(id);
                if(getTeacher == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not find teacher infomation"
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new CustomRespone
                {
                    StatusCode = HttpStatusCode.OK,
                    Result=getTeacher
                });
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var getTeacher = await _teacherServices.GetTeacher(id);
              
                if (getTeacher == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not find teacher infomation"
                    });
                }
                 await _teacherServices.DeleteTeacher(id);
                return StatusCode(StatusCodes.Status200OK, new CustomRespone
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Delete teacher successfully"
                });
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id ,TeacherRequestDTO u_teacher)
        {
            try
            {
                var newTeacher = await _teacherServices.GetTeacher(id);
                if (newTeacher == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Can not find teacher infomation"
                    });
                }
                else
                {
                    newTeacher.FullName = u_teacher.FullName;
                    newTeacher.Phone_Number = u_teacher.Phone_Number;
                    newTeacher.Email = u_teacher.Email;
                    newTeacher.Description = u_teacher.Description;

                    var teacherUpdate = await _teacherServices.UpdateTeacher(newTeacher);
                    
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Update teacher successfully",
                        Result= newTeacher
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
