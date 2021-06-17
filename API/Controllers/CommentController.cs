using Application;
using Application.Commands;
using Application.DTO;
using Application.Queries;
using Application.Searches;
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
    public class CommentController : Controller
    {
        private readonly UseCaseExecutor executor;
        public CommentController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST: api/comment
        [HttpPost]
        public IActionResult Post([FromBody] KomentarDto dto,
            [FromServices] ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // GET: api/comment
        [HttpGet]
        public IActionResult Get(
            [FromQuery] KomentarSearch search,
            [FromServices] IGetCommentQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // DELETE: api/quote
        [HttpDelete]
        public IActionResult Delete([FromBody] KomentarDto id, [FromServices] IDeleteCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }

        // UPDATE: api/quote
        [HttpPut]
        public IActionResult Put([FromBody] KomentarDto id, [FromServices] IUpdateCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(200, "Komentar je uspesno editovan");

        }

    }
}
