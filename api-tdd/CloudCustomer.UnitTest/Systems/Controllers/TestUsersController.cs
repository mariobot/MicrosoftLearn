using CloudCustomer.API.Controllers;
using CloudCustomer.API.Models;
using CloudCustomer.API.Services;
using CloudCustomer.UnitTest.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomer.UnitTest.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.Setup(x => x.GetAllUsers())
             .ReturnsAsync(UsersFixtures.GetTestUsers);
        var sut = new UserController(mockUserService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.
            Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UserController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.
            Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixtures.GetTestUsers);

        var sut = new UserController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    private List<User> UserFixtures()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService.
            Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UserController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}