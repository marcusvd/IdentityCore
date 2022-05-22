

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ViewDto
{
    public class RegisterUserDto
    {
        // [MaxLength(100), MinLength(1)]
        // [Required()]

        public string UserName { get; set; }
        [MaxLength(100), MinLength(1)]
        [Required()]

        public string FullName { get; set; }
        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required()]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



    }
}