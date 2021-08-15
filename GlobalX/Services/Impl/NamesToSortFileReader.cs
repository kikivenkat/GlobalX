using System;
using System.IO;

namespace GlobalX.Services.Impl
{
    public class NamesToSortFileReader : INamesToSortReader
    {
        public string[] GetNamesToSort(string inputPath)
        {
            var inputFileExists = File.Exists(inputPath);

            if (!inputFileExists)
                throw new ArgumentException($"{inputPath} does not point to a file");

            var fileContents = File.ReadAllLines(inputPath);
            return fileContents;
        }
    }
}