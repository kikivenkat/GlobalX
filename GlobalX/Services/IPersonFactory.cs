using System.Collections.Generic;
using GlobalX.Entities;

namespace GlobalX.Services
{
    public interface IPersonFactory
    {
        List<Person> CreatePersons(List<string> nameList);
    }
}