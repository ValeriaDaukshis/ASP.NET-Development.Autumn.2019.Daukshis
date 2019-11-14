namespace Bll.Contract
{
    public interface IUrlParser
    {
        DocumentRecord[] ParseUrl(string[] url);
    }
}