using System;
using System.ComponentModel.DataAnnotations;

namespace _02_Entities.Concrete
{
    public class ShippingDetails
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
