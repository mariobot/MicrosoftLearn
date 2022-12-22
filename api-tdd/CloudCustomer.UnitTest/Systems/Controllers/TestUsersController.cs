using CloudCustomer.API.Controllers;
using CloudCustomer.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomer.UnitTest.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var sut = new UserController();

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserService()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.
            Setup(service => service.Get)
            .ReturnsAsync()
        var sut = new UserController(mockUserService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert

    }
}