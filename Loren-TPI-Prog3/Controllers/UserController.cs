using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Models;
using Loren_TPI_Prog3.Enums;
using Loren_TPI_Prog3.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Loren_TPI_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("UserInfo/")]
        public IActionResult GetUserInfo()
        {
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User? user = _userService.GetUserByEmail(loggedUserEmail);

            if (user != null && user.State)
            {  
                UserInfoDto userInfoDto = new UserInfoDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Address = user.Address,
                    UserType = user.UserType
                };
                return Ok(userInfoDto);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User userLogged = _userService.GetUserByEmail(loggedUserEmail);

            if (role == "Admin" || role == "SuperAdmin" && userLogged.State)
            {
                return Ok(_userService.GetUsersByRole("Client").Value);
            }
            return Forbid();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientPostDto clientPostDto) //sería la registración de un nuevo cliente
        {
            Client client = new Client()
            {
                Email = clientPostDto.Email,
                Name = clientPostDto.Name,
                LastName = clientPostDto.LastName,
                Password = clientPostDto.Password,
                UserName = clientPostDto.UserName,
                Address = clientPostDto.Address
            };
            int id = _userService.CreateUser(client).Value;
            return Ok(id);
        }

        [HttpPost("admin/")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto adminPostDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "SuperAdmin")
            {
                Admin admin = new Admin()
                {
                    Email = adminPostDto.Email,
                    Name = adminPostDto.Name,
                    LastName = adminPostDto.LastName,
                    Password = adminPostDto.Password,
                    UserName = adminPostDto.UserName,
                    UserType = nameof(UserRoleEnum.Admin)
                };
                int id = _userService.CreateUser(admin).Value;
                return Ok(id);
            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientUpdateDto clientUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "Client")
            {
                Client clientToUpdate = new Client()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = clientUpdateDto.UserName,
                    Name = clientUpdateDto.Name,
                    LastName = clientUpdateDto.LastName,
                    Password = clientUpdateDto.Password,
                    Address = clientUpdateDto.Address,
                };
                _userService.UpdateUser(clientToUpdate);
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete]
        public IActionResult DeleteSelfUser() //usuario se borre a sí mismo
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _userService.DeleteUser(id); //borrado lógico (el usuario seguirá en la base de datos)
            return NoContent();
        }
    }
}
