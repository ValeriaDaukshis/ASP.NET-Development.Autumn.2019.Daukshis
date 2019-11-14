using Bll.Contract.Records;

namespace Bll.Contract
{
    public interface IUrlRecordParser
    {
        Record[] ParseUrl(string[] url);
    }
}