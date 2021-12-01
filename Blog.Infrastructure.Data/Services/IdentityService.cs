using Blog.Application.Extensions;
using Blog.Application.Interfaces;
using Blog.Application.Utility;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly IAuthorRepository _authorRepository;


        public IdentityService(UserManager<IdentityUser<int>> userManager,
                                    SignInManager<IdentityUser<int>> signInManager,
                                    IAuthorRepository authorRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorRepository = authorRepository;
        }

        public async Task<Result> GetPasswordReset(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = Result.Success();
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                result.Values = new object[] { new { token, email } };
                return result;
            }
            return Result.Fail(new string[] { });
        }

        //Fali loginResult return ne valja
        public async Task<Result> LoginUser(UserLoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return Result.Fail(new string[] { "Pogrešno korisničko ime ili lozinka" });

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Result.Success();
            }

            return Result.Fail();
        }


        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<Result> RegisterUser(UserRegisterModel model)
        {
            var user = new IdentityUser<int>
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var author = new Author()
                {
                    UserName = model.UserName
                };

                await _authorRepository.createAuthor(author);

                await _authorRepository.save();

                return Result.Success();
            }

            return Result.Fail();
        }

        public async Task<Result> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var identityResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                return identityResult.ToResult();
            }
            return Result.Fail(new string[] { });
        }
    }
}
