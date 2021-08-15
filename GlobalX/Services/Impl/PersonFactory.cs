using System;
using System.Collections.Generic;
using System.Linq;
using GlobalX.Entities;

namespace GlobalX.Services.Impl
{
    public class PersonFactory : IPersonFactory
    {
        public PersonFactory()
        {
            _validator = new NamesValidator();
            _service = new NameSeparatorService();
        }
        public List<Person> CreatePersons(List<string> namesList)
        {
            var personsList = new List<Person>();
            foreach (var name in namesList)
            {
                var isValid = _validator.IsNameListValid(name);

                if (!isValid)
                {
                    throw new ArgumentException($"{name} is not valid.");
                }

                var separatedNameList = _service.GetSeparatedNames(name);
                var lastName = separatedNameList.Last();
                var givenNames = separatedNameList.SkipLast(1).ToList();
                personsList.Add(new Person(lastName, givenNames.ToArray()));
            }

            return personsList;
        }

        private readonly INameSeparatorService _service;
        private readonly INamesValidator _validator;
    }
}