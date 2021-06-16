using Microsoft.AspNetCore.Mvc;
using Scs.Application;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.Application.Exceptions;
using Scs.Application.Queries;
using Scs.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;


        public BrandController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }


        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search, [FromServices] IGetBrandsQuery query)
        {

            //return Ok(query.Execute(search));
            //return Ok(actor);
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<TestController>/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] BrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();

        }
    }
}
