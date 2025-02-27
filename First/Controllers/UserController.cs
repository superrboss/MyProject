using first.EF.Services;
using First.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
namespace First.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }
        [HttpPost]
        public IActionResult AddUser(UserDto NewUser)
        {
            return Ok(_services.AddUser(NewUser));
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_services.GetAllUsers());
        }

        [HttpGet("UserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var UserById = _services.GetUserById(id);
            if (_services.GetUserById(id) == null)
                return NotFound("There is No User Have This Id");
            return Ok(UserById);
        }


        [HttpPut("EditUser/{id}")]
        public IActionResult EditUser([FromBody] EditUserDto updatedUser)
        {
            var existUser = _services.EditUser(updatedUser);
            if (existUser == null)
                return NotFound("User Is Not Found");
            
            return Ok(existUser);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existUser = _services.DeleteUser(id);
            if (existUser == null)
                return NotFound("User Is Not Found");
          
            return Ok(existUser);
        }

        //[Authorize(true)]
        [HttpPost("Login")]
        public IActionResult Login(string User,string Password)
        {
            var CheckUser=_services.login(User, Password);
            if (CheckUser == null)
                return NotFound("User Not Found");

            Response.Headers["Token"] = CheckUser;
            return Ok(new { Token = CheckUser });
        }

        [HttpGet("GetClaim")]
        public IActionResult GetClaimByHeader()
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var token = authorizationHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            var UserId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            return Ok($"email = {email}  UserId= {UserId}");
        }

    }
}

