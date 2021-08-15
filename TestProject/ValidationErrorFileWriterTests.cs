using System.Collections.Generic;
using System.IO;
using GlobalX.Services.Impl;
using NUnit.Framework;

namespace TestProject
{
    public class ValidationErrorFileWriterTests
    {
        [Test]
        public void WritesIntoSortedNamesList_AsExpected()
        {
            var errorList = new List<string>()
            {
                "some random string",
                "some more random string"
            };
            var fileWriter = new ValidationErrorsFileWriter();
            fileWriter.WriteValidationErrors(errorList);

            var actualFileFullPath = Path.Combine($"{TestContext.CurrentContext.TestDirectory}", ValidationErrorsFileWriter.FileName);
            Assert.IsTrue(File.Exists(actualFileFullPath));
            var actualContents = FileReaderUtility.GetFileContents(actualFileFullPath);
            CollectionAssert.AreEqual(errorList, actualContents);
        }
    }
}