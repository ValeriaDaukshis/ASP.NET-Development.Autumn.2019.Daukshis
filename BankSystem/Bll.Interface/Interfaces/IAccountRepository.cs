using System.Dynamic;
using Bll.Interface.Entities;

namespace Bll.Interface.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account item);
        Account Read(string number);
        void Update(Account item);
    }
}