using Application;
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
    public class LogoviController : Controller
    {
        private readonly UseCaseExecutor executor;

        public LogoviController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/logovi
        [HttpGet]
        public IActionResult Get(
            [FromQuery] LogSearch search,
            [FromServices] IGetLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
    }
}
