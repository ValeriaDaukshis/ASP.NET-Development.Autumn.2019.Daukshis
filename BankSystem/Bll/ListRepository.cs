using System.Collections.Generic;
using Bll.Interface.Entities;
using Bll.Interface.Interfaces;

namespace Bll
{
    public class ListRepository : IAccountRepository
    {
        // add method list
        public List<Account> accounts;

        public ListRepository()
        {
            accounts = new List<Account>();
        }
        public void Create(Account item)
        {
            accounts.Add(item);
        }

        public Account Read(string number)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Account item)
        {
            throw new System.NotImplementedException();
        }
    }
}