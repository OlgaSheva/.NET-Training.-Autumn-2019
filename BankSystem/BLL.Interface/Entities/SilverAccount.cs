using System;

namespace BLL.Interface.Entities
{
    class SilverAccount : Account
    {
        public SilverAccount()
        {

        }

        protected override void CalculateBenefitPointsWithDeposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        protected override void CalculateBenefitPointsWithWithdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        protected override bool IsBalanceValid(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
