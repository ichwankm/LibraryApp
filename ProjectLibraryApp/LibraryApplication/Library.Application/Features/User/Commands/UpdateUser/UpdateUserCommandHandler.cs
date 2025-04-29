using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.User.Commands.UpdateUser
{
	internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, int>
	{
		private readonly IUserRepository _userRepository;

		public UpdateUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<int> Handle(UpdateUserCommand command)
		{
			var existingUser = await _userRepository.GetByIdAsync(command.Id);
			if (existingUser == null)
			{
				throw new KeyNotFoundException($"User with Id {command.Id} not found.");
			}

			existingUser.SetUsername(command.UserName);

			await _userRepository.UpdateAsync(existingUser);

			return command.Id;
		}
	}
}
