using System;
using System.Collections.Generic;
using System.IO;
using GlobalX.Utilities;

namespace GlobalX.Services.Impl
{
    public class ValidationErrorsFileWriter : IValidationErrorsWriter
    {
        public const string FileName = "error-log.txt";
        public void WriteValidationErrors(List<string> errors)
        {
            var fullFilePath = Path.Combine(Environment.CurrentDirectory, FileName);
            FileWriterExtension.WriteFile(fullFilePath, errors);
        }
    }
}