using Microsoft.AspNetCore.Mvc;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SreensController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        [HttpPost("create")]
        public async Task<ActionResult<Screen>> CreateScreenAsync([FromBody] Guid guid)
        {
            try
            {
                var screen = new Screen
                {
                    Id = guid,
                };
                await _dbContext.Screens.AddAsync(screen);
                _dbContext.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("confirm")]
        public async Task<ActionResult<Screen>> ConfirmScreenAsync([FromBody] ScreenDto screenDto)
        {
            try
            {
                Screen? screen =  await _dbContext.Screens.FindAsync(screenDto.Id);
                if (screen != null)
                {
                    screen = new Screen
                    {
                        DeviceName = name(screen),
                        BuildingId = screenDto.BuildingId,
                        IsApproved = true
                    };
                    return Ok(screen);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        public string name(Screen screen)
        {
            string count = _dbContext.Screens.Count().ToString();
            string buildingId = screen.BuildingId.ToString();
            string name = $"TV_00{count}_{buildingId}";
            return name;
        }

    }
}
