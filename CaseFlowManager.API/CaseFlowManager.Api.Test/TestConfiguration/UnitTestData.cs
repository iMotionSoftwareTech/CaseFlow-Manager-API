using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration
{
    /// <summary>
    /// The UnitTestData
    /// </summary>
    public static class UnitTestData
    {
        /// <summary>
        /// Gets the create role request.
        /// </summary>
        /// <returns>The <see cref="CreateRoleRequest"</returns>
        public static CreateRoleRequest GetCreateRoleRequest()
        {
            return new CreateRoleRequest
            {
                RoleName = "Test Role",
                Description = "This is a test role"
            };
        }

        /// <summary>
        /// Gets the create task request.
        /// </summary>
        /// <returns>The <see cref="CreateTaskRequest"/>/returns>
        public static CreateTaskRequest GetCreateTaskRequest()
        {
            return new CreateTaskRequest
            {
                CaseworkerId = 1,
                Title = "Test Task",
                Description = "This is a test task",
                DueDateTime = DateTime.UtcNow.AddDays(7)
            };
        }

        /// <summary>
        /// Gets the create user request.
        /// </summary>
        /// <returns>The <see cref="CreateUserRequest"/></returns>
        public static CreateUserRequest GetCreateUserRequest()
        {
            return new CreateUserRequest
            {
                CaseworkerRoleId = 1,
                Forename = "John",
                Surname = "Doe",
                Email = "john.doe@hmcts.org.uk"
            };
        }
    }
}