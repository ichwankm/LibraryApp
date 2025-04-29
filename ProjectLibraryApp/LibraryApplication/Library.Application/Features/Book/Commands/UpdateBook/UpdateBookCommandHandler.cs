using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Book.Commands.UpdateBook
{
	public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand, int>
	{
		private readonly IBookRepository _bookRepository;

		public UpdateBookCommandHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<int> Handle(UpdateBookCommand command)
		{
			var existingBook = await _bookRepository.GetByIdAsync(command.Id);
			if (existingBook == null)
			{
				throw new KeyNotFoundException($"Book with Id {command.Id} not found.");
			}

			existingBook.SetName(command.Name);
			existingBook.SetPrice(command.Price);
			existingBook.SetAmount(command.Amount);

			await _bookRepository.UpdateAsync(existingBook);

			return command.Id;
		}
	}
}