using Application;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : Controller
    {
        private readonly UseCaseExecutor executor;

        public CategoryController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Category
        [Authorize]
        [HttpGet]
        public IActionResult Get(
            [FromQuery] CategorySearch search,
            [FromServices] IGetCategoryQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryDto dto,
            [FromServices] ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();

        }

        // UPDATE: api/Category
        [HttpPut]
        public IActionResult Put([FromBody] CategoryDto id, [FromServices] IUpdateCategoryCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }


    }
}
