using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration
{
    /// <summary>
    /// The UnitTestData
    /// </summary>
    public static class UnitTestData
    {
        /// <summary>
        /// Gets the create role parameter.
        /// </summary>
        /// <returns>The <see cref="CreateRoleRequest"</returns>
        public static CreateRoleRequest GetCreateRoleParameter()
        {
            return new CreateRoleRequest
            {
                RoleName = "Test Role",
                Description = "This is a test role"
            };
        }
    }
}