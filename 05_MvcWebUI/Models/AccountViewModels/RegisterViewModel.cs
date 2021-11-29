using System;
using System.ComponentModel.DataAnnotations;

namespace _05_MvcWebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
