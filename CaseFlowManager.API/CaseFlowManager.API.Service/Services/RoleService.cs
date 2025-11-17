using CaseFlowManager.API.Service.Interfaces;
using CaseFlowManager.API.Service.Utilities;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Services
{
    /// <summary>
    /// The RoleService
    /// </summary>
    /// <seealso cref="CaseFlowManager.API.Service.Interfaces.IRoleService" />
    public class RoleService : IRoleService
    {
        /// <summary>
        /// The role repo
        /// </summary>
        private IRoleRepo _roleRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepo">The role repo.</param>
        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        /// <summary>
        /// Creates the role asynchronous.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>
        /// The <see cref="Task{TResult}" />
        /// </returns>
        public async Task<int> CreateRoleAsync(CreateRoleRequest createRoleRequest)
        {
            return await _roleRepo.CreateRoleAsync(createRoleRequest.ToCreateRoleParameter());
        }

        /// <summary>
        /// Gets all roles asynchronous.
        /// </summary>
        /// <returns>
        /// The <see cref="Task{TResult}}" />
        /// </returns>
        public async Task<IEnumerable<CaseworkerRole>> GetAllRolesAsync()
        {
            var result = await _roleRepo.GetAllRolesAsync();
            return result.ToCaseworkerRoles();
        }
    }
}