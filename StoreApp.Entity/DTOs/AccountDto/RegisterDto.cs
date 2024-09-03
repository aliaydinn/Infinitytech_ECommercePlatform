using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.DTOs.AccountDto
{
    public record RegisterDto
    {
        [Required(ErrorMessage ="UserName is required")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
        [Required(ErrorMessage = "ChechkPassword is required")]
        public string CheckPassword { get; init; }
    }
}
