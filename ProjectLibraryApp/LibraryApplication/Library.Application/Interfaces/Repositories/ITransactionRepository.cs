using Library.Domain.Entities;

namespace Library.Application.Interfaces.Repositories
{
	public interface ITransactionRepository : IRepository<Transaction>
	{
		Task<Transaction?> GetByIdWithDetailsAsync(int id);
		Task<IEnumerable<Transaction>> GetAllWithDetailsAsync();
	}
}
