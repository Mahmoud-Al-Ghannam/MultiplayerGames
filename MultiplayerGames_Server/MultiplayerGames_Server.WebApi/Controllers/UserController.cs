using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.Common.Responses;
using MultiplayerGames_Server.Application.UseCases.User;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.WebApi.Common;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    /// <summary>
    /// Handles user-related operations, including retrieving user information.
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves a list of all registered users.
        /// </summary>
        /// <returns>A collection of <see cref="UserInfoDto"/> objects wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the list of users successfully.</response>
        [HttpGet]
        [ProducesResponseType(
            typeof(BaseResponse<IEnumerable<UserInfoDto>>),
            StatusCodes.Status200OK
        )]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserInfoDto>>>> GetUsers(
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUsersAsync(cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>The user matching the specified ID, wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the user successfully.</response>
        /// <response code="404">If no user is found with the specified ID.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<UserInfoDto>>> GetUserById(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific user by their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>The user matching the specified username, wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the user successfully.</response>
        /// <response code="404">If no user is found with the specified username.</response>
        [HttpGet("{username}/by-username")]
        [ProducesResponseType(typeof(BaseResponse<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<UserInfoDto>>> GetUserByUsername(
            string username,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByUsernameAsync(username, cancellationToken);
            return Ok(response);
        }
    }
}
