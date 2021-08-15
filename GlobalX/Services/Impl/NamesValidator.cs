using System;
using GlobalX.Utilities;

namespace GlobalX.Services.Impl
{
    public class NamesValidator : INamesValidator
    {
        public bool IsNameListValid(string nameList)
        {
            var nameCount = GetNameCount(nameList);
            return nameCount >= Constants.MinimumNameLength && nameCount <= Constants.MaximumNameLength;
        }

        public string GetValidationErrors(string nameList)
        {
            var nameCount = GetNameCount(nameList);
            if (nameCount < Constants.MinimumNameLength)
            {
                return $"{nameList} should have at-least have one given name and one last name.";
            }
            if(nameCount > Constants.MaximumNameLength)
            {
                return $"{nameList} has more than {Constants.MaximumGivenNames} given names.";
            }
            return string.Empty;
        }

        private int GetNameCount(string nameList)
        {
            return nameList.Split(Constants.ValidSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}