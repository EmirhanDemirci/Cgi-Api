using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cgi_Api.Models;
using Cgi_Api.Services.Helpers;
using Cgi_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Cgi_Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginUser user)
        {
            if (user.Username != "" && user.Password != "")
            {
                var jwtUser = _userService.Authenticate(user.Username, user.Password);
                if (jwtUser == null)
                {
                    return BadRequest();
                }

                jwtUser.User = jwtUser.User.WithoutPassword();
                return Ok(jwtUser);
            }
            return BadRequest();
        }

        //[AllowAnonymous]
        //[HttpPost("Planner")]
        //public IActionResult GetPlanner(int id, int isPlanner)
        //{
        //    var user = _userService.Get(id, isPlanner);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(user.WithoutPassword());
        //}
    }
}