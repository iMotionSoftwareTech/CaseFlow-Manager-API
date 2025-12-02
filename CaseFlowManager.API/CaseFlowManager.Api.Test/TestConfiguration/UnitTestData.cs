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

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<Status> GetAllStatuses()
        {
            return new List<Status>
            {
                new Status
                {
                    Id = 1,
                    Title = "Open"
                },
                new Status
                {
                    Id = 2,
                    Title = "In Progress"
                },
                new Status
                {
                    Id = 3,
                    Title = "Closed"
                }
            };
        }

        /// <summary>
        /// Gets all status dto.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<StatusDto> GetAllStatusDto()
        {
            return new List<StatusDto>
            {
                new StatusDto
                {
                    Id = 4,
                    Title = "Awaiting Hearing"
                },
                new StatusDto
                {
                    Id = 5,
                    Title = "Scheduled Hearing"
                },
                new StatusDto
                {
                    Id = 6,
                    Title = "Transferred"
                }
            };
        }

        /// <summary>
        /// Gets all case tasks.
        /// </summary>
        /// <returns>The <see cref="TaskRecord"/></returns>
        public static TaskRecord GetAllCaseTasks()
        {
            return new TaskRecord
            {
                TotalNoOfRecords = 2,
                Tasks = new List<CaseTask>
                {
                    new CaseTask
                    {
                        TaskId = 1,
                        Title = "Task 1",
                        Description = "Description for Task 1",
                        DueDateTime = DateTime.UtcNow.AddDays(3),
                        Status = "Open"
                    },
                    new CaseTask
                    {
                        TaskId = 2,
                        Title = "Task 2",
                        Description = "Description for Task 2",
                        DueDateTime = DateTime.UtcNow.AddDays(5),
                        Status = "In Progress"
                    }
                }
            };
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TaskDto> GetAllTasks()
        {
            return new List<TaskDto>
            {
                new TaskDto
                {
                    TaskId = 3,
                    Title = "Task 3",
                    Description = "Description for Task 3",
                    DueDateTime = DateTime.UtcNow.AddDays(4),
                    Status = "Open"
                },
                new TaskDto
                {
                    TaskId = 4,
                    Title = "Task 4",
                    Description = "Description for Task 4",
                    DueDateTime = DateTime.UtcNow.AddDays(6),
                    Status = "In Progress"
                }
            };
        }

        /// <summary>
        /// Gets the task status dtos.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TaskStatusDto> GetTaskStatusDtos()
        {
            return new List<TaskStatusDto>
            {
                new TaskStatusDto
                {
                    Id = 1,
                    CaseWorker = "John Doe",
                    TaskId = 1,
                    StatusId = 1,
                    Status = "Open",
                    Notes = "Open case created",
                    LogDateTime = DateTime.UtcNow.AddDays(-2)
                },
                new TaskStatusDto
                {
                    Id = 2,
                    CaseWorker = "Jane Doe",
                    TaskId = 2,
                    StatusId = 2,
                    Status = "In Progress",
                    Notes = "Case in progress",
                    LogDateTime = DateTime.UtcNow.AddDays(-1)
                }
            };
        }

        /// <summary>
        /// Gets the task statuses.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseTaskStatus> GetTaskStatuses()
        {
            return new List<CaseTaskStatus>
            {
                new CaseTaskStatus
                {
                    Id = 1,
                    CaseWorker = "Bob Wilkinson",
                    TaskId = 1,
                    StatusId = 2,
                    Status = "In Progress",
                    Notes = "Case in progress",
                    LogDateTime = DateTime.UtcNow.AddDays(2)
                },
                new CaseTaskStatus
                {
                    Id = 2,
                    CaseWorker = "Fred Cotteridge",
                    TaskId = 2,
                    StatusId = 3,
                    Status = "Hearing Scheduled",
                    Notes = "Case hearing scheduled",
                    LogDateTime = DateTime.UtcNow.AddDays(1)
                }
            };
        }

        /// <summary>
        /// Gets the user detail dto.
        /// </summary>
        /// <returns>The <see cref="UserDetailDto"/></returns>
        public static UserDetailDto GetUserDetailDto()
        {
            return new UserDetailDto
            {
                CaseworkerId = 10,
                CaseworkerRoleId = 2,
                Role = "Caseworker",
                Username = "ASmith",
                Forename = "Alice",
                Surname = "Smith",
                Email = "testuser@testsite.com",
                IsLocked = false,
                PasswordAttempt = 0
            };
        }

        /// <summary>
        /// Gets the user detail.
        /// </summary>
        /// <returns>The <see cref="UserDetail"</returns>
        public static UserDetail GetUserDetail()
        {
            return new UserDetail
            {
                CaseworkerId = 11,
                CaseworkerRoleId = 2,
                Role = "Caseworker",
                Username = "ASmith",
                Forename = "Alan",
                Surname = "Smith",
                Email = "testuser@testsite.com",
                IsLocked = false,
                PasswordAttempt = 0
            };
        }
    }
}