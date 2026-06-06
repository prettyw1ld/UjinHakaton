using Microsoft.AspNetCore.Mvc;
using UjinTemplateServer.Common;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateScreensController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        //[HttpGet("{id}")]
        //public async Task<>
    }
}
