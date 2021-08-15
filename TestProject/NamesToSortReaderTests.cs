using System;
using System.IO;
using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class NamesToSortReaderTests
    {
        [Test]
        public void ThrowsExceptionIfFileNotFound()
        {
            var namesToSortReader = new NamesToSortFileReader();
            Assert.Throws<ArgumentException>( () => namesToSortReader.GetNamesToSort("randomPath"));
        }

        [TestCase("unsorted-names-list.txt")]
        public void HappyPath(string fileName)
        {
            var inputFileName = Path.Combine($"{TestContext.CurrentContext.TestDirectory}/TestData", fileName);
            var expectedResult = FileReaderUtility.GetFileContents(inputFileName);
            var namesToSortReader = new NamesToSortFileReader();
            var actualResult = namesToSortReader.GetNamesToSort(inputFileName);
            Assert.IsNotEmpty(actualResult);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }
    }
}