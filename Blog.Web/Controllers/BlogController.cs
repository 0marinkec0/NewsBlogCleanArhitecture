using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IAuthorRepository _authorRepository;
        private readonly IArticleRepository _articleRepository;

        public BlogController(IIdentityService identityService,
            IArticleRepository articleRepository,
            IAuthorRepository authorRepository)
        {
            _identityService = identityService;
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _articleRepository.getAllArticle();
            return View(model);
        }

        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article model)
        {
            if (ModelState.IsValid)
            {
               var aut = await _authorRepository.getAuthorByName((User.Identity.Name).ToString());

                var article = new Article
                {
                    Content = model.Content,
                    Title = model.Title,
                    AuthorId = aut.Id
                };

                await _articleRepository.createArticle(article);
                await _articleRepository.save();

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _articleRepository.getArticleById(id);
             _articleRepository.deleteArticle(model);
            await _articleRepository.save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0) 
            {
                var modelById = await _articleRepository.getArticleById(id);
                return View(modelById);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Article article)
        {
            _articleRepository.updateArticle(article);
            await _articleRepository.save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            _identityService.LogoutUser();

            return RedirectToAction("Index","Home");
        }
    }
}
