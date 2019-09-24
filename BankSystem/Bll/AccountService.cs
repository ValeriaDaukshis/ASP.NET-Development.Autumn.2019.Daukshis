using Bll.Interface.Entities;
using Bll.Interface.Interfaces;

namespace Bll
{
    public class AccountService : IAccountService
    {
        private IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }
        public Account Create(AccountOwner owner, IAccountNumberGenerator numberGenerator)
        {
            throw new System.NotImplementedException();
        }

        public void Close(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Freeze(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Active(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(Account account, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw(Account account, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Transfer(Account account, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}