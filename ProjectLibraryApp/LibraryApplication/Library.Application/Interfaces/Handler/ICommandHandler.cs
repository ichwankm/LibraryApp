namespace Library.Application.Interfaces.Handler
{
	public interface ICommandHandler<TCommand, TResult>
	{
		Task<TResult> Handle(TCommand command);
	}
}
