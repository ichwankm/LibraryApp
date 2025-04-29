using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Transaction.Command.Delete
{
	public class DeleteTransactionCommandHandler : ICommandHandler<DeleteTransactionCommand, int>
	{
		private readonly ITransactionRepository _transactionRepository;

		public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<int> Handle(DeleteTransactionCommand command)
		{
			await _transactionRepository.DeleteAsync(command.Id);

			return command.Id;
		}
	}
}
