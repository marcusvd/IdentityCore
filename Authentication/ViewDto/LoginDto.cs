

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ViewDto
{
    public class LoginDto
    {
        [MaxLength(100), MinLength(1)]
        [Required()]
        public string UserName { get; set; }
        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}