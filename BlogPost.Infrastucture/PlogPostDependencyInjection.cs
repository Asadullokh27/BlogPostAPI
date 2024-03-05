using BlogPost.Application.Abstractions;
using BlogPost.Domain.Entities.Models;
using BlogPost.Infrastucture.Persistance;
using BlogPost.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastucture
{
    public static class PlogPostDependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogPostDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlogPostConnectionString"));
            });
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }

    }
}
