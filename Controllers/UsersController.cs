using Microsoft.AspNetCore.Mvc;
using TimeFourthe.Entities;
using TimeFourthe.Services;
using IdGenerator;

namespace TimeFourthe.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user")]
        public async Task<IActionResult> GetUsers([FromBody] User user)
        {
            var userExist = await _userService.GetUserAsync(user.Email);
            if(userExist!=null){
                if(userExist.Password==user.Password){
                    return Ok(new {error=false,redirectUrl="/timetable",message="Succesfully Login"});
                }
                else{
                    return Ok(new {error=true,redirectUrl="/login",message="Password Incorrect"});
                }
            }
            return Ok(new {error=true,redirectUrl="/login",message="User not exists",data=userExist});
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUserAsync(user);
            return Ok(new { id = user.Id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }



        [HttpGet("data")]
        public IActionResult GetModel()
        {
            string role=HttpContext.Request.Query.ToDictionary(x => x.Key, x => x.Value)["role"][0];
            return Ok(new IdGeneratorClass().IdGenerator(role));
        }
    }
}