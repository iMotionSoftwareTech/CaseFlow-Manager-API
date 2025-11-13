using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace CaseFlowManager.API.Controllers
{
    /// <summary>
    /// The RoleController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<RoleController> _logger;

        /// <summary>
        /// The role service
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="roleService">The role service.</param>
        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        /// <summary>
        /// Creates the caseworker role asynchronous.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>The <see cref="Task{T}"/></returns>
        [HttpPost]
        [Route("CreateCaseworkerRoleAsync")]
        public async Task<ActionResult> CreateCaseworkerRoleAsync(CreateRoleRequest createRoleRequest)
        {
            try
            {
                await this._roleService.CreateRoleAsync(createRoleRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating role.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}