using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController(AppDbContext dbContext) :   
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateScreens>> GetTemplateClientAsync(int id)
        {
            try
            {
                var templateCurrent = await _dbContext.TemplateScreens.FindAsync(id);
                if (templateCurrent != null)
                {
                    var template = await _dbContext.Templates.Where(x => x.Id == id)         
                    
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
    
}
