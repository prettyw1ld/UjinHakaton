using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UjinTemplateServer.Common;
using UjinTemplateServer.Hubs;
using UjinTemplateServer.Hubs.Interface;
using UjinTemplateServer.Models;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreensController(AppDbContext dbContext, IHubContext<ScreenHub, IScreenHub> screenHub) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly IHubContext<ScreenHub, IScreenHub> _screenHub = screenHub;

        [HttpPost("create")]
        public async Task<ActionResult<Screen>> CreateScreenAsync([FromBody] Guid id)
        {
            try
            {
                var screen = new Screen
                {
                    Id = id
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
        public async Task<ActionResult<Screen>> ConfirmScreenAsync([FromBody] Guid Id)
        {
            try
            {
                var screen =  await _dbContext.Screens.FindAsync(Id);
                
                if (screen != null)
                {
                    screen.IsApproved = true;
                    screen.DeviceCode = Name(screen);

                    _dbContext.SaveChanges();
                    var response = new ScreenDtoTo(screen.Id,
                        screen.DeviceCode,
                        screen.BuildingId,
                        screen.IsApproved,
                        screen.TemplateId);
                    await _screenHub.Clients
                        .Group(Id.ToString())
                        .ScreenAuthentificate(response);

                    return Ok(screen);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{screenId}/template/{templateId}")]
        public async Task<IActionResult> SetTemplateAsync(Guid screenId, int templateId)
        {
            var screen = await _dbContext.Screens.FindAsync(screenId);
            if (screen is null)
                return NotFound("Экран не найден");

            var templateExists = await _dbContext.Templates.AnyAsync(x => x.Id == templateId);
            if (!templateExists)
                return NotFound("Шаблон не найден");

            screen.TemplateId = templateId;
            await _dbContext.SaveChangesAsync();

            var response = new ScreenDtoTo(
                screen.Id, 
                screen.DeviceCode,
                screen.BuildingId,
                screen.IsApproved,
                screen.TemplateId);

            await _screenHub.Clients
        .Group(screen.Id.ToString())
        .TemplateChanged(templateId);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ScreenDto>>> GetScreens()
        {
            var screens = await _dbContext.Screens
                .Select(x => new ScreenDto(
                    x.Id,
                    x.DeviceCode,
                    x.IsApproved,
                    x.BuildingId,
                    x.TemplateId))
                .ToListAsync();

            return Ok(screens);
        }

        public string Name(Screen screen)
        {

            int count = _dbContext.Screens.Count();
            string buildingId = screen.BuildingId.ToString();
            string name = $"TV_{count:D3}_{buildingId}";
            return name;
        }
    }
}
