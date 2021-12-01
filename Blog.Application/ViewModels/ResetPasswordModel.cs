using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Password must be inserted")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
