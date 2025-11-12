using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Utilities
{
    /// <summary>
    /// The DomainObjectConverter
    /// </summary>
    public static class DomainObjectConverter
    {
        /// <summary>
        /// Converts to createroleparameter.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>THe <see cref="CreateRoleParameter"/></returns>
        public static CreateRoleParameter ToCreateRoleParameter(this CreateRoleRequest createRoleRequest)
        {
            return new CreateRoleParameter
            {
                RoleName = createRoleRequest.RoleName,
                Description = createRoleRequest.Description
            };
        }
    }
}
