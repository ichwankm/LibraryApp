using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Book.Queries.GetAllBooks
{
	public class GetAllBooksByQueryHandler : IQueryHandler<GetAllBooksQuery, List<BookDTO>>
	{
		private readonly IBookRepository _bookRepository;

		public GetAllBooksByQueryHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<List<BookDTO>> Handle(GetAllBooksQuery query)
		{
			List<BookDTO> listBooks = new List<BookDTO>();

			var books = await _bookRepository.GetAllAsync();

			foreach (var book in books)
			{
				listBooks.Add(BookDTO.FromEntity(book));
			}

			return listBooks;
		}
	}
}
