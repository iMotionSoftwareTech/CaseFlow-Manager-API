using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using IMotionSoftware.CaseFlowManager.API.Controllers;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The UserControllerUnitTests
/// </summary>
[TestClass]
public class UserControllerUnitTests
{
    /// <summary>
    /// The logger mock
    /// </summary>
    private Mock<ILogger<UserController>> _loggerMock;

    /// <summary>
    /// The user service mock
    /// </summary>
    private Mock<IUserService> _userServiceMock;

    /// <summary>
    /// The user controller
    /// </summary>
    private UserController _userController;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<UserController>>();
        _userServiceMock = new Mock<IUserService>();
        _userController = new UserController(_loggerMock.Object, _userServiceMock.Object);
    }

    /// <summary>
    /// Creates the new user asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateNewUserAsync_ReturnsOk_Test()
    {
        // Arrange
        var request = UnitTestData.GetCreateUserRequest();
        this._userServiceMock
            .Setup(s => s.CreateUserAsync(It.IsAny<CreateUserRequest>())).ReturnsAsync(-1);

        // Act
        var result = await _userController.CreateNewUserAsync(request);

        // Assert
        Assert.IsTrue(result is OkResult);
        this._userServiceMock.Verify(service => service.CreateUserAsync(It.IsAny<CreateUserRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the user asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateUserAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var request = UnitTestData.GetCreateUserRequest();
        this._userServiceMock
            .Setup(service => service.CreateUserAsync(It.IsAny<CreateUserRequest>()))
            .ReturnsAsync(0);

        // Act
        var result = await this._userController.CreateNewUserAsync(request);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
        this._userServiceMock.Verify(service => service.CreateUserAsync(It.IsAny<CreateUserRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the user asynchronous throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateUserAsync_ThrowsException_Test()
    {
        // Arrange
        var request = UnitTestData.GetCreateUserRequest();
        this._userServiceMock
            .Setup(service => service.CreateUserAsync(It.IsAny<CreateUserRequest>())).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._userController.CreateNewUserAsync(request);

        // Assert
        var statusCodeResult = result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._userServiceMock.Verify(service => service.CreateUserAsync(It.IsAny<CreateUserRequest>()), Times.Once);
    }

    /// <summary>
    /// Gets the user returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetUser_ReturnsOk_Test()
    {
        // Arrange
        var response = UnitTestData.GetUserDetail();
        this._userServiceMock
            .Setup(service => service.GetUserAsync(It.IsAny<string>())).ReturnsAsync(response);

        // Act
        var result = await this._userController.GetUser("testsite@testsite.com");

        // Assert
        Assert.IsTrue(result is OkObjectResult);
        this._userServiceMock.Verify(service => service.GetUserAsync(It.IsAny<string>()), Times.Once);
    }

    /// <summary>
    /// Gets the user returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetUser_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._userServiceMock
            .Setup(service => service.GetUserAsync(It.IsAny<string>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._userController.GetUser(string.Empty);

        // Assert
        var statusCodeResult = result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._userServiceMock.Verify(service => service.GetUserAsync(It.IsAny<string>()), Times.Once);
    }

    /// <summary>
    /// Updates the password attempt returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task UpdatePasswordAttempt_ReturnsOk_Test()
    {
        // Arrange
        this._userServiceMock
            .Setup(s => s.UpdatePasswordAttemptAsync(It.IsAny<int>())).ReturnsAsync(-1);

        // Act
        var result = await _userController.UpdatePasswordAttempt(1000);

        // Assert
        Assert.IsTrue(result is OkResult);
        this._userServiceMock.Verify(service => service.UpdatePasswordAttemptAsync(It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Updates the password attempt returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task UpdatePasswordAttempt_ReturnsBadRequest_Test()
    {
        // Arrange
        this._userServiceMock
            .Setup(service => service.UpdatePasswordAttemptAsync(It.IsAny<int>()))
            .ReturnsAsync(0);

        // Act
        var result = await this._userController.UpdatePasswordAttempt(10);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
        this._userServiceMock.Verify(service => service.UpdatePasswordAttemptAsync(It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Updates the password attempt throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task UpdatePasswordAttempt_ThrowsException_Test()
    {
        // Arrange
        this._userServiceMock
            .Setup(service => service.UpdatePasswordAttemptAsync(It.IsAny<int>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._userController.UpdatePasswordAttempt(0);

        // Assert
        var statusCodeResult = result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._userServiceMock.Verify(service => service.UpdatePasswordAttemptAsync(It.IsAny<int>()), Times.Once);
    }
}