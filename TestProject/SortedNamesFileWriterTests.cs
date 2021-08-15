using System.Collections.Generic;
using System.IO;
using GlobalX.Entities;
using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class SortedNameFileWriterTests
    {
        [Test]
        public void WritesIntoSortedNamesList_AsExpected()
        {
            var personsList = new List<Person>()
            {
                new Person("lastName", new[] {"givenName"}),
                new Person("lastName1", new[] {"givenName", "oneMore"})
            };
            var fileWriter = new SortedNamesFileWriter();
            fileWriter.WriteSortedNames(personsList);
            var expectedContents = new List<string>()
            {
                "givenName lastName",
                "givenName oneMore lastName1"
            };
            var actualFileFullPath = Path.Combine($"{TestContext.CurrentContext.TestDirectory}", SortedNamesFileWriter.FileName);
            Assert.IsTrue(File.Exists(actualFileFullPath));
            var actualContents = FileReaderUtility.GetFileContents(actualFileFullPath);
            CollectionAssert.AreEqual(expectedContents, actualContents);
        }
    }
}