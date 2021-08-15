using System.Collections.Generic;
using GlobalX.Services.Impl;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using Constants = GlobalX.Utilities.Constants;

namespace TestProject
{
    public class NamesListProcessorTests
    {

        private List<string> _sampleNamesList;
        private List<string> _expectedValidNamesList;
        private List<string> _expectedValidationErrors;
        [SetUp]
        public void Setup()
        {
            _sampleNamesList = new List<string>()
                                {
                                    "abc bcd efg",
                                    "ang sdf",
                                    "dfg try jklkj wer wer",
                                    "wer rty asd ioh",
                                    "wer"
                                };
            _expectedValidNamesList = new List<string>()
                            {
                                "abc bcd efg",
                                "ang sdf",
                                "wer rty asd ioh",
                            };
            _expectedValidationErrors = new List<string>()
            {
                $"dfg try jklkj wer wer has more than {Constants.MaximumGivenNames} given names.",
                "wer should have at-least have one given name and one last name."
            };
        }

        [Test]
        public void GetValidNamesList_WorksAsExpected()
        {
            var processor = new NamesListProcessor(_sampleNamesList);
            var actualValidNamesList = processor.GetValidNamesList();
            CollectionAssert.AreEqual(actualValidNamesList, _expectedValidNamesList);
        }

        [Test]
        public void GetValidationErrors_WorksAsExpected()
        {
            var processor = new NamesListProcessor(_sampleNamesList);
            var actualValidationErrors = processor.GetValidationErrors();
            CollectionAssert.AreEqual(actualValidationErrors, _expectedValidationErrors);
        }
    }
}