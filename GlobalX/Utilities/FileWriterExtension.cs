using System.Collections.Generic;
using System.IO;

namespace GlobalX.Utilities
{
    public static class FileWriterExtension
    {
        public static void WriteFile(string fileName, List<string> content)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllLinesAsync(fileName, content);
        }
    }
}