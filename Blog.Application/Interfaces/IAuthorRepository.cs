using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task createAuthor(Author author);
        Task<Author> getAuthorByName(string name);
        Task save();
    }
}
