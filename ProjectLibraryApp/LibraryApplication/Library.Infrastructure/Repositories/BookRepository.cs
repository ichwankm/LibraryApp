using Library.Application.Interfaces.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.DbContext;

namespace Library.Infrastructure.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		public BookRepository(LibraryDbContext dbContext) : base(dbContext)
		{
		}
	}
}
