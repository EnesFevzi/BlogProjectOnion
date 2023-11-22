using BlogProjectOnion.Domain.Repositories;
using BlogProjectOnion.Infrastructure.Context;
using BlogProjectOnion.Infrastructure.Repositories;
using BlogProjectOnion.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProjectOnion.Infrastructure.Extensions
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			services.AddScoped<IUnıtOfWork, UnitOfWork>();

			return services;


		}
	}
}
