using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineXO_Server.Infrastructure.SignalR.Hubs.XOGameHub;

namespace OnlineXOServer.WebApi.Controllers
{
    [Route("api/v1/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<XOGameHub, IXOGameHubClient> _hubContext;

        public TestController(IHubContext<XOGameHub, IXOGameHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToGroup(string group)
        {
            await _hubContext.Clients.Group(group).GameDeletedAsync("gg-id");
            return Ok();
        }
    }
}
