using System.Collections.Generic;
using GlobalX.Entities;

namespace GlobalX.Services
{
    public interface ISortedNamesWriter
    {
        void WriteSortedNames(List<Person> sortedNames);
    }
}