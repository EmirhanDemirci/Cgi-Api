using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cgi_Api.Models;
using Cgi_Api.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cgi_Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        // GET: api/CgiShifts
        [HttpGet]
        public ActionResult<IEnumerable<Shift>> GetCgiShift()
        {
            try
            {
                return Ok(_shiftService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Shift> GetCgiShift(int id)
        {
            try
            {
                return Ok(_shiftService.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCgiShift(int id, Shift cgiShift)
        {
            try
            {
                _shiftService.Put(id, cgiShift);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        public ActionResult<Shift> PostCgiShift(Shift cgiShift)
        {
            try
            {
                _shiftService.Post(cgiShift);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        public async Task<ActionResult<Shift>> DeleteCgiShift(int id)
        {
            try
            {
                return Ok(_shiftService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
    }
}