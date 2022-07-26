using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using contractor.Models;
using contractor.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;

namespace contractor.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {

        private readonly CompaniesService _cs;
        // private readonly JobsService _js;
        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
            // _js = js;
        }
        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            try
            {
                List<Company> companies = _cs.Get();
                return Ok(companies);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            try
            {
                Company company = _cs.Get(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("{id}/jobs")]
        // public ActionResult<List<Job>> GetJobs(int id)
        // {
        //     try
        //     {
        //         List<Job> jobs = _cs.GetJobs(id);
        //         return Ok(jobs);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }




        [HttpPost]
        [Authorize]
        public ActionResult<Company> Create([FromBody] Company company)
        {
            try
            {
                Company newCompany = _cs.Create(company);
                return Created($"/api/companies/{newCompany.Id}", newCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
    }
