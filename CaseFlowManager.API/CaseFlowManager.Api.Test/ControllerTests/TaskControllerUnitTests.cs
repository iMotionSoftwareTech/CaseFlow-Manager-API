using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using IMotionSoftware.CaseFlowManager.API.Controllers;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The TaskControllerUnitTests
/// </summary>
[TestClass]
public class TaskControllerUnitTests
{
    /// <summary>
    /// The logger mock
    /// </summary>
    private Mock<ILogger<TaskController>> _loggerMock;

    /// <summary>
    /// The task service mock
    /// </summary>
    private Mock<ITaskService> _taskServiceMock;

    /// <summary>
    /// The task controller
    /// </summary>
    private TaskController _taskController;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<TaskController>>();
        _taskServiceMock = new Mock<ITaskService>();
        _taskController = new TaskController(_loggerMock.Object, _taskServiceMock.Object);
    }

    /// <summary>
    /// Creates the case task asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ReturnsOk_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()))
            .ReturnsAsync(-1);

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        Assert.IsTrue(result is OkResult);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the case task asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()))
            .ReturnsAsync(0);

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the case task asynchronous throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ThrowsException_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>())).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        var statusCodeResult = result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsOk_Test()
    {
        // Arrange
        var statuses = UnitTestData.GetAllStatuses();
        this._taskServiceMock
            .Setup(service => service.GetAllStatusesAsync()).ReturnsAsync(statuses);

        // Act
        var result = await this._taskController.GetAllStatusesAsync();

        // Assert
        Assert.IsTrue(result is OkObjectResult);
        this._taskServiceMock.Verify(service => service.GetAllStatusesAsync(), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._taskServiceMock
            .Setup(service => service.GetAllStatusesAsync())
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.GetAllStatusesAsync();

        // Assert
        var statusCodeResult = result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.GetAllStatusesAsync(), Times.Once);
    }
}