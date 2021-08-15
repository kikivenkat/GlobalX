using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject
{
    public class FileReaderUtility
    {
        public static List<string> GetFileContents(string fileName)
        {
            return File.Exists(fileName) ? File.ReadAllLines(fileName).ToList() : null;
        }
    }
}