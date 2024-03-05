using BlogPost.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application
{
    public static class ApplicationDependencyInjection
    {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddScoped<IBlogPostService, BlogPostService>();
                services.AddScoped<IAuthorizationService, AuthorizationService>();
                services.AddScoped<IUserService, UserService>();
                return services;
            }
    }
}
