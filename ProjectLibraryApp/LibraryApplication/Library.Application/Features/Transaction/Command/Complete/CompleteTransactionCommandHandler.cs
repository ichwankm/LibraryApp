using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Transaction.Command.Complete
{
	public class CompleteTransactionCommandHandler : ICommandHandler<CompleteTransactionCommand, int>
	{
		private readonly ITransactionRepository _transactionRepository;

		public CompleteTransactionCommandHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<int> Handle(CompleteTransactionCommand command)
		{
			var transaction = await _transactionRepository.GetByIdWithDetailsAsync(command.TransactionId);

			if (transaction == null)
				throw new KeyNotFoundException($"Transaction with Id {command.TransactionId} not found.");

			transaction.CompleteTransaction(command.ReturnDate);

			await _transactionRepository.UpdateAsync(transaction);

			return command.TransactionId;
		}
	}
}
