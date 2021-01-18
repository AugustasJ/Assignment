using HomeAssignmentLibrary.API.WebServices;

namespace HomeAssignmentLibrary.API.Helpers
{
    public class InterestCalculator
    {
        public static decimal GetInterestRate(string baseRateCode, decimal margin)
        {
            var baseRateValue = VilibBaseRateProvider.GetVilibRate(baseRateCode);
            return baseRateValue + margin;
        }

        public static decimal GetDifference(string currentBaseRateCode, string newBaseRateCode, decimal margin)
        {
            decimal currentInterestRate = GetInterestRate(currentBaseRateCode, margin);
            decimal newInterestRate = GetInterestRate(newBaseRateCode, margin); ;

            return currentInterestRate - newInterestRate;
        }
    }
}
