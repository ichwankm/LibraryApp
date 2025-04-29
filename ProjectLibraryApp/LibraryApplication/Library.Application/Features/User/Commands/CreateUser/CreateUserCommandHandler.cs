using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.User.Commands.CreateUser
{
	public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, int>
	{
		private readonly IUserRepository _userRepository;

		public CreateUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<int> Handle(CreateUserCommand command)
		{
			var user = new Domain.Entities.User(command.UserName);

			await _userRepository.AddAsync(user);

			return user.Id;
		}
	}
}
