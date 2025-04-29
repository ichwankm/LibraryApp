using Library.Application.Interfaces.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
	public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
	{
		public TransactionRepository(LibraryDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Transaction>> GetAllWithDetailsAsync()
		{
			return await _context.Transactions
						.Include(t => t.Book)
						.Include(t => t.User)
						.ToListAsync();
		}

		public async Task<Transaction?> GetByIdWithDetailsAsync(int id)
		{
			return await _context.Transactions
						.Include(t => t.Book)
						.Include(t => t.User)
						.FirstOrDefaultAsync(t => t.Id == id);
		}
	}
}