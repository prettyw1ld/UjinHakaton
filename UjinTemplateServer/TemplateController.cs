using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UjinTemplateServer
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController(AppDbContext dbContext) : ControllerBase
    {
        public readonly AppDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<Templates>> GetTemplatesAsync()
        {
            try
            {
                List<Templates> templates = await _dbContext.Templates.ToListAsync();



                return Ok(templates);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
