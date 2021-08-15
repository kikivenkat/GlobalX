using System.Collections.Generic;
using GlobalX.Entities;

namespace GlobalX.Services
{
    public interface INameSorterService
    {
        List<Person> GetSortedList(List<Person> personsList);
    }
}