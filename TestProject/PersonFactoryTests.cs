using System;
using System.Collections.Generic;
using GlobalX.Entities;
using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class PersonFactoryTests
    {

        [Test]
        public void CreatePerson_WorksAsExpected()
        {
            var namesList = new List<string>()
            {
                "givenName lastName",
                "givenName1 givenName2 lastName",
            };
            var expectedPersonsList = new List<Person>()
            {
                new Person("lastName", new[] {"givenName"}),
                new Person("lastName", new[] {"givenName1", "givenName2"})
            };
            var factory = new PersonFactory();
            var actualPersonList = factory.CreatePersons(namesList);
            Assert.AreEqual(actualPersonList.Count, expectedPersonsList.Count);
            for (var i = 0; i < actualPersonList.Count; i++)
            {
                Assert.AreEqual(actualPersonList[i].LastName, expectedPersonsList[i].LastName);
                CollectionAssert.AreEqual(actualPersonList[i].GivenNames, expectedPersonsList[i].GivenNames);
            }
        }

        [Test]
        public void ThrowsException_IfPersonNameDoeSNotMeetMinimumLength()
        {
            var namesList = new List<string>()
            {
                "oneName",
                "givenName1 givenName2 lastName",
            };
            var factory = new PersonFactory();
            Assert.Throws<ArgumentException>(() => factory.CreatePersons(namesList));
        }

        [Test]
        public void ThrowsException_IfPersonHasMoreThanMaxAllowedGivenNames()
        {
            var namesList = new List<string>()
            {
                "givenName1 givenName2 givenName3 givenName4 lastName",
            };
            var factory = new PersonFactory();
            Assert.Throws<ArgumentException>(() => factory.CreatePersons(namesList));
        }
    }
}