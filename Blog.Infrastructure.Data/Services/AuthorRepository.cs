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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BlogDbContext _dbContext;

        public AuthorRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task createAuthor(Author author)
        {
             await _dbContext.AddAsync(author);
        }

        public async Task<Author> getAuthorByName(string name)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(u => u.UserName == name);
        }

        public async Task save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
