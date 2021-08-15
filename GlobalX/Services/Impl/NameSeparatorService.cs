using System;
using GlobalX.Utilities;

namespace GlobalX.Services.Impl
{
    public class NameSeparatorService : INameSeparatorService
    {
        public string[] GetSeparatedNames(string namesToSeparate)
        {
            return namesToSeparate.Split(Constants.ValidSeparators,StringSplitOptions.RemoveEmptyEntries);
        }
    }
}