using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class ForgottenPasswordModel
    {
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Email must be inserted")]
        public string Email { get; set; }
    }
}
