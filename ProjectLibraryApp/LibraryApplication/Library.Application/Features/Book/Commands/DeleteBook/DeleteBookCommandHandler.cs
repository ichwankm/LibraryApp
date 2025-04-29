using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Book.Commands.DeleteBook
{
	public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, int>
	{
		private readonly IBookRepository _bookRepository;

		public DeleteBookCommandHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<int> Handle(DeleteBookCommand command)
		{
			await _bookRepository.DeleteAsync(command.Id);

			return command.Id;
		}
	}
}
