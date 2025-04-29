using Library.Application.Interfaces.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Services
{
	public class AppMediator : IAppMediator
	{
		private readonly IServiceProvider _serviceProvider;

		public AppMediator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
		{
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			var handler = _serviceProvider.GetRequiredService(handlerType);

			var method = handlerType.GetMethod("Handle")!;
			return (Task<TResult>)method.Invoke(handler, new object[] { query })!;
		}

		public Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
		{
			var handlerType = typeof(ICommandHandler<,>).MakeGenericType(typeof(TCommand), typeof(TResult));
			var handler = _serviceProvider.GetRequiredService(handlerType);

			var method = handlerType.GetMethod("Handle")!;
			return (Task<TResult>)method.Invoke(handler, new object[] { command })!;
		}
	}
}
