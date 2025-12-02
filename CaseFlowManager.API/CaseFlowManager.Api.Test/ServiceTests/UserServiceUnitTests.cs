using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The UserServiceUnitTests
/// </summary>
[TestClass]
public class UserServiceUnitTests
{
    /// <summary>
    /// The user repo mock
    /// </summary>
    private Mock<IUserRepo> _userRepoMock;

    /// <summary>
    /// The user service
    /// </summary>
    private UserService _userService;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _userRepoMock = new Mock<IUserRepo>();
        _userService = new UserService(_userRepoMock.Object);
    }

    /// <summary>
    /// Creates the user is successfull test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateUser_IsSuccessfull_Test()
    {
        // Arrange
        var request = UnitTestData.GetCreateUserRequest();
        this._userRepoMock
            .Setup(repo => repo.CreateUserAsync(It.IsAny<CreateUserParameter>())).ReturnsAsync(1);

        // Act
        var result = await this._userService.CreateUserAsync(request);

        // Assert
        Assert.AreEqual(1, result);
        this._userRepoMock.Verify(repo => repo.CreateUserAsync(It.IsAny<CreateUserParameter>()), Times.Once);
    }

    /// <summary>
    /// Gets the user asynchronous is successfull test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetUserAsync_IsSuccessfull_Test()
    {
        // Arrange
        var response = UnitTestData.GetUserDetailDto();
        this._userRepoMock
            .Setup(repo => repo.GetUserAsync(It.IsAny<string>())).ReturnsAsync(response);

        // Act
        var result = await this._userService.GetUserAsync("testuser@testsite.com");

        // Assert
        Assert.IsNotNull(result);
        this._userRepoMock.Verify(repo => repo.GetUserAsync(It.IsAny<string>()), Times.Once);
    }

    /// <summary>
    /// Updates the password attempt asynchronous is successfull test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task UpdatePasswordAttemptAsync_IsSuccessfull_Test()
    {
        // Arrange
        this._userRepoMock
            .Setup(repo => repo.UpdatePasswordAttemptAsync(It.IsAny<int>())).ReturnsAsync(-1);

        // Act
        var result = await this._userService.UpdatePasswordAttemptAsync(1);

        // Assert
        Assert.AreEqual(-1, result);
        this._userRepoMock.Verify(repo => repo.UpdatePasswordAttemptAsync(It.IsAny<int>()), Times.Once);
    }
}