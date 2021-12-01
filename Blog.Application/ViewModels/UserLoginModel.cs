using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class UserLoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must enter valid username!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter valid password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
