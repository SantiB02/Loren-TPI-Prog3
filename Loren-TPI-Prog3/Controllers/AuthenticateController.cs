using Loren_TPI_Prog3.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loren_TPI_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IUserService _userService;
        public IConfiguration _config;

        public AuthenticateController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
        {
            //valido usuario
            BaseResponse validarUsuarioResult = _userService.ValidarUsuario(credentialsDto.Email, credentialsDto.Password);
        }
    }
}
