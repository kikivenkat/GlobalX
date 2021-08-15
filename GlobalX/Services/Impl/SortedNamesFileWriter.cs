using System;
using System.Collections.Generic;
using System.IO;
using GlobalX.Entities;
using GlobalX.Utilities;

namespace GlobalX.Services.Impl
{
    public class SortedNamesFileWriter : ISortedNamesWriter
    {
        public const string FileName = "sorted-names-list.txt";
        public void WriteSortedNames(List<Person> sortedPersonsList)
        {
            var fullFilePath = Path.Combine(Environment.CurrentDirectory, FileName);

            var sortedNames = NamesExtensions.GetSortedNames(sortedPersonsList);
            FileWriterExtension.WriteFile(fullFilePath, sortedNames);
        }
    }
}