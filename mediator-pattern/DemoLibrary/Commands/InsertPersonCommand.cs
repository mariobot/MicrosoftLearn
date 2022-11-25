using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Commands
{
    public class InsertPersonCommand : IRequest<PersonModel>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }

        public InsertPersonCommand(string firstName, string lastName)
        {
            FirsName = firstName;
            LastName = lastName;
        }
    }
}
