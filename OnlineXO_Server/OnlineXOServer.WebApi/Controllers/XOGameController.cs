using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineXO_Server.Application.Common.Responses;
using OnlineXO_Server.Application.UseCases.XOGame;
using OnlineXO_Server.Application.UseCases.XOGame.RequestDTOs;
using OnlineXO_Server.Application.UseCases.XOGame.ResponseDTOs;

namespace OnlineXOServer.WebApi.Controllers
{
    [Route("api/v1/xo-games")]
    [Authorize]
    [ApiController]
    public class XOGameController : ControllerBase
    {
        private readonly XOGameService _xOGameService;

        public XOGameController(XOGameService xOGameService)
        {
            _xOGameService = xOGameService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<GameItemDto>>>> GetGames(
            [FromQuery] GetGamesQueryDto query,
            CancellationToken cancellationToken
        )
        {
            var response = await _xOGameService.GetGamesAsync(query, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<GameInfoDto>>> GetGame(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _xOGameService.GetGameAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<string>>> CreateGame(
            CancellationToken cancellationToken
        )
        {
            var response = await _xOGameService.CreateGameAsync(cancellationToken);
            return Ok(response);
        }

        [HttpPost("{id}/join")]
        public async Task<ActionResult<BaseResponse<object>>> JoinGame(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _xOGameService.JoinAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpPost("{id}/leave")]
        public async Task<ActionResult<BaseResponse<object>>> LeaveGame(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _xOGameService.LeaveAsync(id, cancellationToken);
            return Ok(response);
        }
    }
}
