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
    public class CompaniesController : ControllerBase
    {

        private readonly CompaniesService _cs;
        private readonly JobsService _js;
        public CompaniesController(CompaniesService cs, JobsService js)
        {
            _cs = cs;
            _js = js;
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

        [HttpGet("{id}/contractors")]
        public ActionResult<List<Job>> GetContractors(int id)
        {
            try
            {
                List<ContractorJobViewModel> jobs = _js.GetByCompanyId(id);
                return Ok(jobs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




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
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Company> Edit(int id, [FromBody] Company company)
        {
            try
            {
                Company editedCompany = _cs.Edit(company);
                return Ok(editedCompany);
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
                 _cs.Delete(id);
                return Ok("Company deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
    }
