using IMotionSoftware.CaseFlowDataPackage.DomainObjects;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
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

        /// <summary>
        /// Converts to createtaskparameter.
        /// </summary>
        /// <param name="createTaskRequest">The create task request.</param>
        /// <returns>The <see cref="CreateTaskParameter"/></returns>
        public static CreateTaskParameter ToCreateTaskParameter(this CreateTaskRequest createTaskRequest)
        {
            return new CreateTaskParameter
            {
                CaseworkerId = createTaskRequest.CaseworkerId,
                Title = createTaskRequest.Title,
                Description = createTaskRequest.Description,
                DueDateTime = createTaskRequest.DueDateTime
            };
        }

        /// <summary>
        /// Converts to createuserparameter.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>The <see cref="CreateUserParameter"/></returns>
        public static CreateUserParameter ToCreateUserParameter(this CreateUserRequest createUserRequest)
        {
            return new CreateUserParameter
            {
                CaseworkerRoleId = createUserRequest.CaseworkerRoleId,
                Forename = createUserRequest.Forename,
                Surname = createUserRequest.Surname,
                Email = createUserRequest.Email,
                PasswordHash = createUserRequest.PasswordHash,
                PasswordSalt = createUserRequest.PasswordSalt,
                CreatedDateTime = createUserRequest.CreatedDateTime
            };
        }

        /// <summary>
        /// Converts to caseworkerrole.
        /// </summary>
        /// <param name="caseworkerRoles">The caseworker role.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRole> ToCaseworkerRoles(this IEnumerable<CaseworkerRoleDto> caseworkerRoles)
        {
            var roles = new List<CaseworkerRole>();
            foreach (var role in caseworkerRoles)
            {
                roles.Add(new CaseworkerRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                });
            };

            return roles;
        }
    }
}