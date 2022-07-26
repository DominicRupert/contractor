using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contractor.Models;
using contractor.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace contractor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cons;
        private readonly JobsService _js;
        
    

    public ContractorsController(ContractorsService cons, JobsService js)
    {
        _cons = cons;
        _js = js;
    }

    [HttpGet]

    public ActionResult<List<Contractor>> Get()
    {
        try
        {
            List<Contractor> contractors = _cons.Get();
            return Ok(contractors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
        try
        {
            Contractor contractor = _cons.Get(id);
            return Ok(contractor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }


    }

    [HttpGet("{id}/companies")]
    public ActionResult<List<ContractorJobViewModel>> GetCompanies(int id)
    {
        try
        {
            List<ContractorJobViewModel> companies = _js.GetByContractorId(id);
            return Ok(companies);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Contractor> Create([FromBody] Contractor contractor)
    {
        try
        {
            Contractor newContractor = _cons.Create(contractor);
            return Created($"/api/contractors/{newContractor.Id}", newContractor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut ("{id}")]
    [Authorize]
    public ActionResult<Contractor> Edit(int id, [FromBody] Contractor contractor)
    {
        try
        {
            Contractor editedContractor = _cons.Edit(id, contractor);
            return Ok(editedContractor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete ("{id}")]
    [Authorize]
    public ActionResult<Contractor> Delete(int id)
    {
        try
        {
             _cons.Delete(id);
            return Ok("ur fired");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    }









}



