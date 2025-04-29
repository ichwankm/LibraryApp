namespace Library.Application.Interfaces.Handler
{
	public interface IAppMediator
	{
		Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default);
		Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default);
	}
}
