using Bll.Interface.Entities;

namespace Bll.Interface.Interfaces
{
    public interface IAccountService
    {
        Account Create(AccountOwner owner, IAccountNumberGenerator numberGenerator);
        void Close(Account account);
        void Freeze(Account account);
        void Active(Account account);
        void Deposit(Account account, decimal amount);
        void Withdraw(Account account, decimal amount);
        void Transfer(Account account, decimal amount);
    }
}