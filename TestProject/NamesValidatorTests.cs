using GlobalX.Services.Impl;
using GlobalX.Utilities;
using NUnit.Framework;

namespace TestProject
{
    public class NamesValidatorTests
    {
        [TestCase("GivenName LastName", true)]
        [TestCase("GivenName SecondGivenName LastName", true)]
        [TestCase("GivenName SecondGivenName ThirdGivenName LastName", true)]
        [TestCase("GivenName SecondGivenName ThirdGivenName FourthGivenName LastName", false)]
        [TestCase("OnlyOneName", false)]
        public void IsValidWorksAsExpected(string nameList, bool isValid)
        {
            var namesValidator = new NamesValidator();
            var isNameListValid = namesValidator.IsNameListValid(nameList);
            Assert.AreEqual(isNameListValid,isValid);
        }

        [Test]
        public void ValidationErrorAsExpected_When_MoreThanMaximumNameLength()
        {
            var namesListToValidate = GetNamesListToValidate(Constants.MaximumNameLength + 1);
            var namesValidator = new NamesValidator();
            var actualErrorMsg = namesValidator.GetValidationErrors(namesListToValidate);
            var expectedErrorMsg = $"{namesListToValidate} has more than {Constants.MaximumGivenNames} given names.";
            Assert.AreEqual(actualErrorMsg, expectedErrorMsg);
        }

        [Test]
        public void ValidationErrorAsExpected_When_NameDoesNotMatchMinimumLength()
        {
            var namesListToValidate = GetNamesListToValidate(Constants.MinimumNameLength - 1);
            var namesValidator = new NamesValidator();
            var actualErrorMsg = namesValidator.GetValidationErrors(namesListToValidate);
            var expectedErrorMsg = $"{namesListToValidate} should have at-least have one given name and one last name.";
            Assert.AreEqual(actualErrorMsg, expectedErrorMsg);
        }

        [TestCase(Constants.MaximumNameLength)]
        [TestCase(Constants.MinimumNameLength)]
        public void NoValidationError_WhenNameListIsAsExpected(int nameLength)
        {
            var namesListToValidate = GetNamesListToValidate(nameLength);
            var namesValidator = new NamesValidator();
            var actualErrorMsg = namesValidator.GetValidationErrors(namesListToValidate);
            Assert.IsEmpty(actualErrorMsg);
        }

        private static string GetNamesListToValidate(int count)
        {
            var nameList = string.Empty;

            for (var i = 0; i < count; i++)
            {
                nameList += $"abc{i}" + Constants.ValidSeparators[0];
            }

            return nameList;
        }
    }
}