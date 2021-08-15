using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class NameSeparatorServiceTests
    {
        [Test]
        public void ReturnsSeparatedNames()
        {
            var namesToSeparate = "GivenName AnotherOne OneMore LastName";
            var expectedResult = new [] {"GivenName", "AnotherOne", "OneMore", "LastName"};
            var namesSeparatorService = new NameSeparatorService();
            var actualResult = namesSeparatorService.GetSeparatedNames(namesToSeparate);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void WorksIfThereAreEmptyEntries()
        {
            //three spaces between AnotherOne and OneMore.
            var namesToSeparate = "GivenName AnotherOne   OneMore LastName";
            var expectedResult = new [] { "GivenName", "AnotherOne", "OneMore", "LastName" };
            var namesSeparatorService = new NameSeparatorService();
            var actualResult = namesSeparatorService.GetSeparatedNames(namesToSeparate);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }
    }
}