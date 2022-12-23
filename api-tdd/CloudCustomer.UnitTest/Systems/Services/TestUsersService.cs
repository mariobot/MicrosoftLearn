using CloudCustomer.API.Models;
using CloudCustomer.API.Services;
using CloudCustomer.UnitTest.Fixtures;
using CloudCustomer.UnitTest.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomer.UnitTest.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokedHttpGetRequest()
        {
            // Arrage
            var expectedResponse = UsersFixtures.GetTestUsers;
            var handlerMock = MockHttpMessageHandler<User>.Setup(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            // Act
            await sut.GetAllUsers();

            // Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
        
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnListOfUsers()
        {
            // Arrage
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            // Act
            var result = await sut.GetAllUsers();

            // Assert
            result.Count.Should().Be(0);

        }

    }
}
