
namespace Task1
{
    public interface IIndexer
    { 
        int GetNext(int index);
        int GetPrev(int index); 
        int GetHeigherElem(int index);
        int First { get; }
        int Last { get;  } 
        int GetMedium(int high, int low);
    }
}
