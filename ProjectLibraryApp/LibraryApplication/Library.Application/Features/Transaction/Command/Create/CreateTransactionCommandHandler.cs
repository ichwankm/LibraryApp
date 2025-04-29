using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Transaction.Command.Create
{
	public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, int>
	{
		private readonly ITransactionRepository _transactionRepository;

		public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<int> Handle(CreateTransactionCommand command)
		{
			var transaction = new Domain.Entities.Transaction(command.bookId, command.userId, command.borrowDate);

			await _transactionRepository.AddAsync(transaction);

			return transaction.Id;
		}
	}
}
