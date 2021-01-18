using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAssignmentLibrary.API.Entities
{
    public class Agreement
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string BaseRateCode { get; set; }
        
        public string NewBaseRateCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Margin { get; set; }

        [Required]
        public int AgreementDuration { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public Guid CustomerId { get; set; }
    }
}
