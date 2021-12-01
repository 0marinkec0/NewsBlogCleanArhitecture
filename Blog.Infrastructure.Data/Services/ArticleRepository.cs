using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogDbContext _dbContext;

        public ArticleRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task createArticle(Article article)
        {
            await _dbContext.AddAsync(article);
        }

        public void deleteArticle(Article article)
        {
             _dbContext.Remove(article);
        }

        public async Task<List<Article>> getAllArticle()
        {
            return await _dbContext.Articles.ToListAsync();
        }

        public async Task<Article> getArticleById(int id)
        {
            return await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task updateArticle(Article article, int id)
        {
            var articl = await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            article.Title = articl.Content;
            article.Content = articl.Content;

        }
    }
}
