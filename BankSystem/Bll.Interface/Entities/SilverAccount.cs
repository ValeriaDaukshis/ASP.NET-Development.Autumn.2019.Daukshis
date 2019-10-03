namespace Bll.Interface.Entities
{
    public class SilverAccount : Account
    {
        // initialize benefitPoints from config file
        //now they are private fields
        private const int BenefitPointsWithDeposit = 2;
        private const int BenefitPointsWithWithdraw = 2;
        private const decimal CreditValidBalance = -50;
        protected override bool IsBalanceValid(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        protected override void CalculateBenefitPointsWithDeposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        protected override void CalculateBenefitPointsWithWithdraw(decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}