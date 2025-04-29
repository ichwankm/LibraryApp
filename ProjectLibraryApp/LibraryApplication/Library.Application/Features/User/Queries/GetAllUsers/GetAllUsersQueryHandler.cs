using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.User.Queries.GetAllUsers
{
	public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, List<UserDTO>>
	{
		private readonly IUserRepository _userRepository;

		public GetAllUsersQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<List<UserDTO>> Handle(GetAllUsersQuery query)
		{
			List<UserDTO> listUsers = new List<UserDTO>();

			var users = await _userRepository.GetAllAsync();

			foreach (var user in users)
			{
				listUsers.Add(UserDTO.FromEntity(user));
			}

			return listUsers;
		}
	}
}