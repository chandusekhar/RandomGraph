using System.Collections.Generic;
using System.IO;

namespace RandomGraph
{
    public class FileLoader : IDataLoader
    {
        private readonly string _fileName;

        public FileLoader(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<string> LoadData()
        {
            using (var reader = new StreamReader(_fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
