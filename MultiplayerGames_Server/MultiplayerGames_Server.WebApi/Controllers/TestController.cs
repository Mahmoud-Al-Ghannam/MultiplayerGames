using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MultiplayerGames_Server.Application.UseCases.Test;
using MultiplayerGames_Server.Infrastructure.SignalR.Hubs.XOGameHub;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    [Route("api/v1/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> IncreaseCounter()
        {
            return Ok(await _testService.IncreaseCounterAsync());
        }
    }
}
