using System;

namespace Bll.Interface.Entities
{
    public abstract class Account : IEquatable<Account>
    {
        public AccountOwner Owner { get; set; }
        public AccountState State { get; set; }
        private string number;
        private decimal balance;
        private int benefitPoints;

        public override bool Equals(Object obj)
        {
            return base.Equals(obj);
        }
        
        public bool Equals(Account obj)
        {
            return base.Equals(obj);
        }

        public Account()
        {
            
        }
        public void Close() => State = AccountState.closed;

        public void Transfer(Account account, decimal amount)
        {
            
        }
        // pattern template method
        public void Deposit(decimal amount)
        {
            if (this.State == AccountState.closed || this.State == AccountState.freezed)
            {
                throw new ArgumentException(); //bad
            }
            this.balance += amount;
            CalculateBenefitPointsWithDeposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (!IsBalanceValid(amount) || this.State == AccountState.closed || this.State == AccountState.freezed)
            {
                throw new ArgumentException(); //bad
            }
            this.balance -= amount;
            CalculateBenefitPointsWithWithdraw(amount);
        }

        protected abstract bool IsBalanceValid(decimal amount);
        //protected abstract void IsBalanceValid();
        protected abstract void CalculateBenefitPointsWithDeposit(decimal amount);
        protected abstract void CalculateBenefitPointsWithWithdraw(decimal amount);
    }
}