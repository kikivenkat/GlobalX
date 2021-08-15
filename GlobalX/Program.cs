using System;
using System.Collections.Generic;
using System.Linq;
using GlobalX.Entities;
using GlobalX.Services;
using GlobalX.Services.Impl;
using GlobalX.Utilities;

namespace GlobalX
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = args[0];

                INamesToSortReader inputReader = new NamesToSortFileReader();
                IPersonFactory personFactory = new PersonFactory();
                INameSorterService nameSorterService = new NameSorterService();
                ISortedNamesWriter sortedNamesWriter = new SortedNamesFileWriter();
                IValidationErrorsWriter validationErrorsWriter = new ValidationErrorsFileWriter();

                var namesToSort = inputReader.GetNamesToSort(inputPath);

                INamesListProcessor processor = new NamesListProcessor(namesToSort.ToList());

                var validNamesListToSort = processor.GetValidNamesList();

                List<Person> sortedList = null;

                if (validNamesListToSort != null && validNamesListToSort.Count > 0)
                {
                    var persons = personFactory.CreatePersons(validNamesListToSort);

                    sortedList = nameSorterService.GetSortedList(persons);
                }

                if (sortedList != null && sortedList.Count > 0)
                {
                    sortedNamesWriter.WriteSortedNames(sortedList);
                    WriteToConsole(NamesExtensions.GetSortedNames(sortedList));
                }
                var validationErrors = processor.GetValidationErrors();
                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrorsWriter.WriteValidationErrors(validationErrors);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void WriteToConsole(List<string> contentList)
        {
            foreach (var content in contentList)
            {
                Console.WriteLine(content);
            }
        }
    }
}
