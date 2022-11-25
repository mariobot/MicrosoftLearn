using DemoLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoLibrary.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DataAccess()
        {
            people.Add(new PersonModel() { Id = 1, FirstName = "Tim", LastName = "Corey" });
            people.Add(new PersonModel() { Id = 2, FirstName = "Sue", LastName = "Storm" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel InsertPeople(string fistName, string lastName)
        {
            PersonModel p = new() { FirstName = fistName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }
    }
}
