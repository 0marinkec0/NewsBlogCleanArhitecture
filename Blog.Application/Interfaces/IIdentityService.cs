using Blog.Application.Utility;
using Blog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> RegisterUser(UserRegisterModel model);
        Task<Result> LoginUser(UserLoginModel model);
        Task<Result> GetPasswordReset(string email);
        Task<Result> ResetPassword(ResetPasswordModel model);
        Task LogoutUser();
    }
}
