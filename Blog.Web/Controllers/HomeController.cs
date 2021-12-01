using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityService _identityService;

        public HomeController(
            ILogger<HomeController> logger,
            IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForgottenPassword()
        {
            return View();
        }

        public IActionResult Login()
        {
            return RedirectToAction("ForgottenPassword", "Account");
        }

        [HttpPost]
         public async Task<IActionResult> Login(UserLoginModel model)
         {
            if (ModelState.IsValid)
            {
                var result = await _identityService.LoginUser(model);

                if (result.IsSucessfull)
                {
                    return RedirectToAction("Index","Blog");
                }
            }
            return View("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.RegisterUser(model);

                if (result.IsSucessfull)
                {
                    return RedirectToAction("Successs");
                } 
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
