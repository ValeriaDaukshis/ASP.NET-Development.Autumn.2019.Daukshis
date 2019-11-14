using Bll.Contract.Records;

namespace Bll.Contract.Serializers
{
    public interface IXmlSerializer
    {
        void Serialize(DocumentRecords record);
    }
}