using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineXO_Server.Application.Common.Responses;
using OnlineXO_Server.Application.UseCases.User;
using OnlineXO_Server.Application.UseCases.User.ResponseDTOs;

namespace OnlineXOServer.WebApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserInfoDto>>>> GetUsers(
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUsersAsync(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserInfoDto>>>> GetUserById(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{username}/by-username")]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserInfoDto>>>> GetUserByUsername(
            string username,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByUsernameAsync(username, cancellationToken);
            return Ok(response);
        }
    }
}
