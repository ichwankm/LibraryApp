using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Book.Commands.CreateBook
{
	public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, int>
	{
		private readonly IBookRepository _bookRepository;

		public CreateBookCommandHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<int> Handle(CreateBookCommand command)
		{
			var book = new Domain.Entities.Book(command.Name, command.Price, command.Amount);

			await _bookRepository.AddAsync(book);

			return book.Id;
		}
	}
}
