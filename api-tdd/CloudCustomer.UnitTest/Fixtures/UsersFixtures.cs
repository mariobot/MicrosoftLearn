using CloudCustomer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomer.UnitTest.Fixtures
{
    public static class UsersFixtures
    {
        public static List<User> GetTestUsers => new List<User> {
            new User {
                Id = 1,
                Name="Jane",
                Address = new Address(){
                    City = "Boston",
                    Street = "123 st 2",
                    ZipCode = "1555"
                },
                Email = "jane@example.com"
            },
            new User {
                Id = 2,
                Name="Bob",
                Address = new Address(){
                    City = "Boston",
                    Street = "123 st 2",
                    ZipCode = "1555"
                },
                Email = "jane@example.com"
            },
            new User {
                Id = 3,
                Name="Carl",
                Address = new Address(){
                    City = "Boston",
                    Street = "123 st 2",
                    ZipCode = "1555"
                },
                Email = "jane@example.com"
            }
        };
    }
}
