using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Transaction.Queries.GetTransactionById
{
	public class GetTransactionByIdQueryHandler : IQueryHandler<GetTransactionByIdQuery, TransactionDTO>
	{
		private readonly ITransactionRepository _transactionRepository;

		public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<TransactionDTO> Handle(GetTransactionByIdQuery query)
		{
			var transactionById = await _transactionRepository.GetByIdWithDetailsAsync(query.Id);

			if (transactionById == null)
			{
				throw new KeyNotFoundException($"Transaction with Id {query.Id} not found.");
			}

			return TransactionDTO.FromEntity(transactionById);
		}
	}
}
