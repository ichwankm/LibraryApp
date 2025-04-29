using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.User.Commands.DeleteUser
{
	public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, int>
	{
		private readonly IUserRepository _userRepository;

		public DeleteUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<int> Handle(DeleteUserCommand command)
		{
			await _userRepository.DeleteAsync(command.Id);

			return command.Id;
		}
	}
}
