using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using contractor.Models;
using contractor.Services;


namespace contractor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;

        public JobsController(JobsService js)
        {
            _js = js;
        }

        [HttpPost]
        [Authorize]

        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                Job createdJob = _js.Create(newJob);
                return Ok(createdJob);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> Delete(int id)
        {
            try
            {
               _js.Delete(id);
                return Ok("Job deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}