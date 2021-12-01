using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class UserRegisterModel
    {
        [StringLength(10, ErrorMessage = "Username must have maximum 10 characters")]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "*Username is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*Email address is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
    }
}
