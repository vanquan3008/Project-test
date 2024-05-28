using Microsoft.AspNetCore.Mvc;
using QLyProject.DTOs.RequestsDTO;
using QLyProject.DTOs.ResponesDTO;
using QLyProject.Respone;
using QLyProject.Services.IService;
using System.Net;
using QLyProject.Models;
using Npgsql.TypeMapping;

namespace QLyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Register")]
        public async Task<IActionResult> Login(UserRequestDTO user)
        {
            try
            {
                var userRgt = await _userService.CreateUser(user);
                return StatusCode(StatusCodes.Status200OK, new CustomRespone
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Create user successfully",
                    Result = new UserResponeDTO
                    {
                        Age = userRgt.Age,
                        Email = userRgt.Email,
                        FullName= userRgt.FullName
                    }
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Get user successfully",
                        Result = new UserResponeDTO
                        {
                            Age = user.Age,
                            Email = user.Email,
                            FullName = user.FullName
                        }
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "User not exists",

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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return StatusCode(StatusCodes.Status200OK, new CustomRespone
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Delete user successfully",
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
        public async Task<IActionResult> Update(int id, UserUpdateRequestDTO user)
        {
            try
            {
                var userUpdate = await _userService.GetUser(id);
                if (userUpdate != null)
                {
                    userUpdate.Age = user.Age;
                    userUpdate.FullName = user.FullName;
                    userUpdate.Email = user.Email;
                    var UpdateUser = await _userService.UpdateUser(userUpdate);
                    return StatusCode(StatusCodes.Status200OK, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Update user successfully",
                        Result = new UserResponeDTO
                        {
                            Age = UpdateUser.Age,
                            Email = UpdateUser.Email,
                            FullName =UpdateUser.FullName

                        }
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new CustomRespone
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "User not exists",

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
