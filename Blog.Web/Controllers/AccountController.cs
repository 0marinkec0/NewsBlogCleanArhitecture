using Blog.Application.Interfaces;
using Blog.Application.Utility;
using Blog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public AccountController(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;       
        }

        public IActionResult ForgottenPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgottenPasswordAsync(ForgottenPasswordModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _identityService.GetPasswordReset(model.Email);

                if (result.IsSucessfull)
                {
                    var link = Url.Action("ResetPassword", "Account", result.Values[0], Request.Scheme);
                    EmailMessage message = EmailGenerator.GeneratePasswordResetMessage(link, model.Email);
                    await _emailService.SendEmailAsync(message);
                }
            }
            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            ResetPasswordModel model = new ResetPasswordModel
            {
                Token = token,
                Email = email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                await _identityService.ResetPassword(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
