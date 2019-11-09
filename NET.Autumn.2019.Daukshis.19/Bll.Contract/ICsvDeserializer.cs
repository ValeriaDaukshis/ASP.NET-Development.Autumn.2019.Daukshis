namespace Bll.Contract
{
    public interface ICsvDeserializer
    {
        string[] Deserialize(string path);
    }
}