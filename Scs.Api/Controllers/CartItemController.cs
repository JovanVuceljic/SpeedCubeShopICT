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
    public class CartItemController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CartItemController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor= actor;
        }

        // GET: api/<CartItemController>
        [HttpGet]
        public IActionResult Get([FromQuery] CartItemSearch search, [FromServices] IGetCartItemQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<CartItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartItemController>
        [HttpPost]
        public void Post([FromBody] CartItemDto dto, [FromServices] ICreateCartItemCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<CartItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCartItemCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
