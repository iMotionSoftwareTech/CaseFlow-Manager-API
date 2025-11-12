using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Interfaces
{
    /// <summary>
    /// The IRoleService
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Creates the role asynchronous.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>The <see cref="Task"/></returns>
        Task CreateRoleAsync(CreateRoleRequest createRoleRequest);
    }
}