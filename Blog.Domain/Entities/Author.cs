using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Articles = new List<Article>();
        }

        public string UserName { get; set; }
        public List<Article> Articles { get; private set; }
    }
}
