using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.User.Queries.GetUserById
{
	public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDTO>
	{
		private readonly IUserRepository _userRepository;

		public GetUserByIdQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDTO> Handle(GetUserByIdQuery query)
		{
			var userById = await _userRepository.GetByIdAsync(query.Id);

			if (userById == null)
			{
				throw new KeyNotFoundException($"User with Id {query.Id} not found.");
			}

			return UserDTO.FromEntity(userById);
		}
	}
}
