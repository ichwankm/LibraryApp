using Library.Application.Interfaces.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.DbContext;

namespace Library.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(LibraryDbContext context) : base(context)
		{
		}
	}
}
