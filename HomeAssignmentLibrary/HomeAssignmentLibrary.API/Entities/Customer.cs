using System;
using System.ComponentModel.DataAnnotations;

namespace HomeAssignmentLibrary.API.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PersonalId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
