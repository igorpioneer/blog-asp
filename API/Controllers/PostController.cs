using Application;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using Implementation.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly UseCaseExecutor executor;

        public PostController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST: api/post
        [HttpPost]
        public IActionResult Post([FromForm] PostDto dto,
            [FromServices] ICreatePostCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201, "Post Je napravljen");
        }

        // GET: api/post
        [HttpGet]
        public IActionResult Get(
            [FromQuery] PostSearch search,
            [FromServices] IGetPostQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // DELETE: api/post
        [HttpDelete]
        public IActionResult Delete([FromBody] PostDto id, [FromServices] IDeletePostCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }

        // UPDATE: api/post
        [HttpPut]
        public IActionResult Put([FromBody] PostDto id, [FromServices] IUpdatePostCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(200, "Post update successfully");

        }
    }
}
