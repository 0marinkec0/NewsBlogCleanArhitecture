using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Infrastructure.Data.Context;
using Blog.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Infrastructure
{
    public class DependencyInjection
    {
        public static void RegistrationServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
                o.Password.RequiredUniqueChars = 0;
                o.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<BlogDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        public static void AddDbContext(IServiceCollection services, string connString)
        {
            services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(connString));       
        }
    }
}
