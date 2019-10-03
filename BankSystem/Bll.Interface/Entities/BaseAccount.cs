namespace Bll.Interface.Entities
{
    public class BaseAccount : Account
    {
        // initialize benefitPoints from config file
        //now they are private fields
        private const int BenefitPointsWithDeposit = 1;
        private const int BenefitPointsWithWithdraw = 1;
        private const decimal CreditValidBalance = 0;
        private decimal BenefitPoints { get; set; }
        protected override bool IsBalanceValid(decimal amount)
        {
            if (amount > CreditValidBalance)
                return true;
            return false;
        }

        protected override void CalculateBenefitPointsWithDeposit(decimal amount)
        {
            BenefitPoints += amount * BenefitPointsWithDeposit / 100;
        }

        protected override void CalculateBenefitPointsWithWithdraw(decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}