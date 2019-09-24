namespace Bll.Interface.Entities
{
    public class SilverAccount : Account
    {
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