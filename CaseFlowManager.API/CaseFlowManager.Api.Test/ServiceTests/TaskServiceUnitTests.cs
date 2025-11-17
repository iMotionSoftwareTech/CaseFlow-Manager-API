using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test
{
    /// <summary>
    /// The TaskServiceUnitTests
    /// </summary>
    [TestClass]
    public class TaskServiceUnitTests
    {
        /// <summary>
        /// The task repo mock
        /// </summary>
        private Mock<ITaskRepo> _taskRepoMock;

        /// <summary>
        /// The task service
        /// </summary>
        private TaskService _taskService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _taskRepoMock = new Mock<ITaskRepo>();
            _taskService = new TaskService(_taskRepoMock.Object);
        }

        /// <summary>
        /// Creates the task is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task CreateTask_IsSuccessfull_Test()
        {
            // Arrange
            var request = UnitTestData.GetCreateTaskRequest();
            this._taskRepoMock
                .Setup(repo => repo.CreateTaskAsync(It.IsAny<CreateTaskParameter>()))
                .ReturnsAsync(1);

            // Act
            var result = await this._taskService.CreateTaskAsync(request);

            // Assert
            Assert.AreEqual(1, result);
            this._taskRepoMock.Verify(repo => repo.CreateTaskAsync(It.IsAny<CreateTaskParameter>()), Times.Once);
        }
    }
}