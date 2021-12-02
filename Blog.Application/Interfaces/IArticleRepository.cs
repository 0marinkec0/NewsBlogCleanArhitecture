using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IArticleRepository
    {
        Task createArticle(Article article);
        void deleteArticle(Article article);
        void updateArticle(Article article);

        Task<List<Article>> getAllArticle();
        Task<Article> getArticleById(int id);

        Task save();
    }
}
