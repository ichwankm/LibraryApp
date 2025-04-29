namespace Library.Application.Interfaces.Handler
{
	public interface IQueryHandler<TQuery, TResult>
	{
		Task<TResult> Handle(TQuery query);
	}
}
