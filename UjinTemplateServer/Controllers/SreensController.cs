using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UjinTemplateServer.Common;
using UjinTemplateServer.Hubs;
using UjinTemplateServer.Hubs.Interface;
using UjinTemplateServer.Models;

namespace UjinTemplateServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SreensController(AppDbContext dbContext, IHubContext<ScreenHub, IScreenHub> screenHub) : ControllerBase
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
        public async Task<ActionResult<Screen>> ConfirmScreenAsync([FromBody] ScreenDtoFromServer screenDto)
        {
            try
            {
                var screen =  await _dbContext.Screens.FindAsync(screenDto.Id);
                if (screen != null)
                {
                    screen.BuildingId = screenDto.BuildingId;
                    screen.IsApproved = true;
                    screen.DeviceCode = Name(screen);

                    _dbContext.SaveChanges();
                    var response = new ScreenDtoTo(screen.Id, screen.DeviceCode, screen.BuildingId, screen.IsApproved, screen.TemplateId);
                    await _screenHub.Clients.All.ScreenAuthentificate(response);

                    return Ok(screen);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
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
