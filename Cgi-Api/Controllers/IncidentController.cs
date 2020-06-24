using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cgi_Api.Models;
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

    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        [AllowAnonymous]
        [HttpPost("{userId}/Create")]
        public IActionResult CreateIncident(Incident incident, int userId)
        {
            try
            {
                _incidentService.Create(incident, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpGet("{userId}/Get")]
        public IActionResult GetIncident(int userId)
        {
            try
            {

                return Ok(_incidentService.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("{userId}/Delete")]
        public IActionResult DeleteIncident([FromRoute]int userId, [FromBody]int incidentId)
        {
            try
            {
                _incidentService.Delete(incidentId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("{userId}/Complete")]
        public IActionResult CompleteIncident([FromRoute]int userId, [FromBody]int incidentId)
        {
            try
            {
                _incidentService.Success(incidentId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}