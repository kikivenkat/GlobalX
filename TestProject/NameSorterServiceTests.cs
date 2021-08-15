using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.Entities;
using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class NamesSorterServiceTests
    {
        [TestCase("unsorted-names-list.txt", "sorted-names-list.txt")]
        public void HappyPath(string unsortedFileName, string sortedFileName)
        {
            var unsortedFullPath = Path.Combine($"{TestContext.CurrentContext.TestDirectory}/TestData", unsortedFileName);
            var sortedFullPath = Path.Combine($"{TestContext.CurrentContext.TestDirectory}/TestData", sortedFileName);

            var unsortedNameList = FileReaderUtility.GetFileContents(unsortedFullPath);
            var sortedNameList = FileReaderUtility.GetFileContents(sortedFullPath);

            var unsortedPersonsList = GetPersonList(unsortedNameList);
            var expectedPersonsList = GetPersonList(sortedNameList);

            var nameSorterService = new NameSorterService();
            var actualResult = nameSorterService.GetSortedList(unsortedPersonsList);

            Assert.IsNotEmpty(actualResult);
            Assert.AreEqual(actualResult.Count, expectedPersonsList.Count);
            for (var i = 0; i < actualResult.Count; i++)
            {
                Assert.AreEqual(actualResult[i].LastName, expectedPersonsList[i].LastName);
                CollectionAssert.AreEqual(actualResult[i].GivenNames, expectedPersonsList[i].GivenNames);
            }
        }

        private static List<Person> GetPersonList(List<string> namesList)
        {
            var personsList = new List<Person>();
            foreach (var nameRow in namesList)
            {
                var names = nameRow.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var lastName = names.Last();
                var givenNames = names.SkipLast(1).ToArray();
                personsList.Add(new Person(lastName, givenNames));
            }

            return personsList;
        }
    }
}