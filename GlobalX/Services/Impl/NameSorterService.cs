using System.Collections.Generic;
using System.Linq;
using GlobalX.Entities;
using GlobalX.Utilities;

namespace GlobalX.Services.Impl
{
    public class NameSorterService : INameSorterService
    {
        public List<Person> GetSortedList(List<Person> personsList)
        {
            var paddedPersonsList = NamesExtensions.GetPaddedPersonsList(personsList);
            var sortedList = paddedPersonsList.OrderBy(x => x.LastName)
                .ThenBy(x => x.GivenNames[0])
                .ThenBy(x => x.GivenNames[1])
                .ThenBy(x => x.GivenNames[2])
                .ToList();
            return GetTrimmedPersonsList(sortedList);
        }

        private List<Person> GetTrimmedPersonsList(List<Person> personsList)
        {
            var trimmedList = new List<Person>();
            foreach (var person in personsList)
            {
                var trimmedGivenNames = person.GivenNames
                                                               .Where(x => !string.IsNullOrWhiteSpace(x))
                                                               .ToArray();
                trimmedList.Add(new Person(person.LastName, trimmedGivenNames));
            }

            return trimmedList;
        }
    }
}