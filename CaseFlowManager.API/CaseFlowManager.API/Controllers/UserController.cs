using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMotionSoftware.CaseFlowManager.API.Controllers
{
    /// <summary>
    /// The UserController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger<UserController> _logger;

        /// <summary>
        /// The user service
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userService">The user service.</param>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Creates the new user asynchronous.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpPost]
        [Route("CreateNewUserAsync")]
        public async Task<ActionResult> CreateNewUserAsync(CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await this._userService.CreateUserAsync(createUserRequest);
                if (result != -1)
                    return BadRequest("User creation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user.");
                return StatusCode(500, "Internal server error");
            }

            return Ok();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpGet]
        [Route("GetUser/{email}")]
        public async Task<ActionResult> GetUser(string email)
        {
            try
            {
                var result = await this._userService.GetUserAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates the password attempt.
        /// </summary>
        /// <param name="caseworkerId">The caseworker identifier.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpPut]
        [Route("UpdatePasswordAttempt/{caseworkerId}")]
        public async Task<ActionResult> UpdatePasswordAttempt(int caseworkerId)
        {
            try
            {
                var result = await this._userService.UpdatePasswordAttemptAsync(caseworkerId);
                if (result != -1)
                    return BadRequest("Updating password attempt failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating password attempt.");
                return StatusCode(500, "Internal server error");
            }
            return Ok();
        }
    }
}