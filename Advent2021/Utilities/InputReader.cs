using System.Collections.Generic;
using System.IO;

namespace Advent2021.Utilities
{
    public class InputReader
    {
        public IEnumerable<string> ReadLine(string fileName)
        {
            string line;
            using (var reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
