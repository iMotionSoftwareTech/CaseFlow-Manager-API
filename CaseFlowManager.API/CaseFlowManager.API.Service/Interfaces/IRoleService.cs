using IMotionSoftware.CaseFlowManager.API.Models.Models;
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
        /// <returns>The <see cref="Task{TResult}"/></returns>
        Task<int> CreateRoleAsync(CreateRoleRequest createRoleRequest);

        /// <summary>
        /// Gets all roles asynchronous.
        /// </summary>
        /// <returns>The <see cref="Task{TResult}}"/></returns>
        Task<IEnumerable<CaseworkerRole>> GetAllRolesAsync();
    }
}