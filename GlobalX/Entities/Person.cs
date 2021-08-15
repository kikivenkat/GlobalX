using System;
using GlobalX.Utilities;

namespace GlobalX.Entities
{
    public class Person
    {
        public Person(string lastName, string[] givenNames)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("A person must have a last name");
            }

            if (givenNames == null || givenNames.Length == 0 || string.IsNullOrWhiteSpace(givenNames[0]))
            {
                throw new ArgumentException("A person should have at-least one given name");
            }

            if (givenNames.Length > Constants.MaximumGivenNames)
            {
                throw new ArgumentException($"A person can not have more than {Constants.MaximumGivenNames} given names");
            }

            LastName = lastName;
            GivenNames = givenNames;
        }
        public string LastName { get; }
        public string[] GivenNames { get; }
    }
}
