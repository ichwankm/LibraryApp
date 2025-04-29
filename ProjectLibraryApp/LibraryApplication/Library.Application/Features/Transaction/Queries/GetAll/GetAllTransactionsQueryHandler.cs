using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Transaction.Queries.GetAll
{
	public class GetAllTransactionsQueryHandler : IQueryHandler<GetAllTransactionsQuery, List<TransactionDTO>>
	{
		private readonly ITransactionRepository _transactionRepository;
		
		public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<List<TransactionDTO>> Handle(GetAllTransactionsQuery query)
		{
			List<TransactionDTO> listTransactions = new List<TransactionDTO>();

			var transactions = await _transactionRepository.GetAllWithDetailsAsync();

			foreach (var transaction in transactions)
			{
				listTransactions.Add(TransactionDTO.FromEntity(transaction));
			}

			return listTransactions;
		}
	}
}
