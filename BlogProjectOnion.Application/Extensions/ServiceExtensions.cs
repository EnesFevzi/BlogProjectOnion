using BlogProjectOnion.Application.FluentValidation;
using BlogProjectOnion.Application.Helpers.Abstract;
using BlogProjectOnion.Application.Helpers.Concrete;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Application.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace BlogProjectOnion.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
           
            services.AddAutoMapper(assembly);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<PostValidator>();
                    opt.DisableDataAnnotationsValidation = true;
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });

            return services;


        }
    }
}
