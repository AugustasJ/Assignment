using System;

namespace HomeAssignmentLibrary.API.Models
{
    public class ResponseDto
    {
        public Guid Id { get; set; }
        public long PersonalId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string BaseRateCode { get; set; }
        public string NewBaseRateCode { get; set; }
        public decimal Margin { get; set; }
        public int AgreementDuration { get; set; }
        public decimal InterestRateForCurrentBaseRate { get; set; }
        public decimal InterestRateForNewBaseRate { get; set; }
        public decimal InterestRateDifference { get; set; }
    }
}
