using Application;
using Application.Commands;
using Application.DTO;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcenaController : Controller
    {
        private readonly UseCaseExecutor executor;

        public OcenaController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST: api/ocena
        [HttpPost]
        public IActionResult Post([FromBody] OcenaDto dto,
            [FromServices] ICreateOcenaCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // GET: api/comment
        [HttpGet]
        public IActionResult Get(
            [FromQuery] OcenaSearch search,
            [FromServices] IGetOcenaQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // DELETE: api/rate
        [HttpDelete]
        public IActionResult Delete([FromBody] OcenaDto id, [FromServices] IDeleteOcenaCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }

        // UPDATE: api/rate
        [HttpPut]
        public IActionResult Put([FromBody] OcenaDto id, [FromServices] IUpdateOcenaCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(200, "Ocena uspesno izmenjena");

        }
    }
}

