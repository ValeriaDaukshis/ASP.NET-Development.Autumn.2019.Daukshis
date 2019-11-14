using Bll.Contract;

namespace Bll.Implementation3
{
    public class DocumentCsvFileReader : ICsvFileReader
    {
        public string[] Deserialize(string path)
        {
            return path.Split("\r\n");
        }
    }
}