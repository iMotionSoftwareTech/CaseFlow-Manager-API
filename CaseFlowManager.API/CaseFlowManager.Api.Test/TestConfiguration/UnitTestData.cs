using IMotionSoftware.CaseFlowDataPackage.DomainObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
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

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRoleDto> GetAllRoles()
        {
            return new List<CaseworkerRoleDto>
            {
                new CaseworkerRoleDto
                {
                    Id = 1,
                    Name = "Role 1",
                    Description = "Description for Role 1"
                },
                new CaseworkerRoleDto
                {
                    Id = 2,
                    Name = "Role 2",
                    Description = "Description for Role 2"
                }
            };
        }

        /// <summary>
        /// Gets all caseworker roles.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRole> GetAllCaseworkerRoles()
        {
            return new List<CaseworkerRole>
            {
                new CaseworkerRole
                {
                    Id = 3,
                    Name = "Role 3",
                    Description = "Description for Role 3"
                },
                new CaseworkerRole
                {
                    Id = 4,
                    Name = "Role 4",
                    Description = "Description for Role 4"
                }
            };
        }
    }
}