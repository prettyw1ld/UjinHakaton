using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjinTemplateServer.Common;
using UjinTemplateServer.Models;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController(AppDbContext dbContext) : ControllerBase
    {
        public readonly AppDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<Template>> GetTemplatesAsync()
        {
            try
            {
                List<Template> templates = await _dbContext.Templates.ToListAsync();

                return Ok(templates);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
