using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cgi_Api.Models;
using Cgi_Api.Services;
using Cgi_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cgi_Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase 
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult CreateSchedule(Schedule schedule, int userId)
        {
            try
            {
                _scheduleService.create(schedule, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}