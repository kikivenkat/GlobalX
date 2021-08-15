using System.Collections.Generic;
using System.Linq;
using GlobalX.Entities;

namespace GlobalX.Utilities
{
    public static class NamesExtensions
    {
        private static List<string> GetPaddedNames(List<string> nameList, int expectedLength)
        {
            var paddedList = new List<string>();
            paddedList.AddRange(nameList);
            while (paddedList.Count < expectedLength)
            {
                paddedList.Add("");
            }
            return paddedList;
        }

        public static List<Person> GetPaddedPersonsList(List<Person> personsList)
        {
            var paddedList = new List<Person>();
            foreach (var person in personsList)
            {
                string[] paddedGivenNames = null;
                if (person.GivenNames.Length < Constants.MaximumGivenNames)
                {
                    paddedGivenNames = GetPaddedNames(person.GivenNames.ToList(),
                                                            Constants.MaximumGivenNames)
                                                      .ToArray();
                }
                paddedList.Add(new Person(person.LastName, paddedGivenNames ?? person.GivenNames));
            }

            return paddedList;
        }

        public static List<string> GetSortedNames(List<Person> sortedPersonsList)
        {
            return (from person in sortedPersonsList
                let givenNames = string.Join(" ", person.GivenNames)
                select $"{givenNames} {person.LastName}").ToList();
        }
    }
}