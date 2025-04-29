using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;
using Library.Infrastructure.DbContext;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			// Register DbContext from the Infrastructure Layer with the connection string
			services.AddDbContext<LibraryDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
			);

			// Register Repositories from the Infrastructure Layer
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<ITransactionRepository, TransactionRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			// Register AppMediator (dispatcher for Command/Query)
			services.AddScoped<IAppMediator, AppMediator>();

			// Register Base Repository
			services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

			return services;
		}
	}
}
