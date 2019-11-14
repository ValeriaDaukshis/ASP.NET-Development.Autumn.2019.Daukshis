namespace Bll.Contract
{
    public interface ICsvFileReader
    {
        string[] Deserialize(string path);
    }
}