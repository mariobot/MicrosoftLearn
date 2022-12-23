using CloudCustomer.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var sut = new UserService();

            // Act
            await sut.GetAllUsers();


        
        }

    }
}
