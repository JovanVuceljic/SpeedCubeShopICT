using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scs.Application;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
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
    public class ProductsController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ProductsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
