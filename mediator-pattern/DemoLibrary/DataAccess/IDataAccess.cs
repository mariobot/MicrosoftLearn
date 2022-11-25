using DemoLibrary.Models;
using System.Collections.Generic;

namespace DemoLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<PersonModel> GetPeople();
        PersonModel InsertPeople(string fistName, string lastName);
    }
}