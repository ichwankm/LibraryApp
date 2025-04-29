using Library.Application.DTOs;
using Library.Application.Interfaces.Handler;
using Library.Application.Interfaces.Repositories;

namespace Library.Application.Features.Book.Queries.GetBookById
{
	public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, BookDTO>
	{
		private readonly IBookRepository _bookRepository;

		public GetBookByIdQueryHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<BookDTO> Handle(GetBookByIdQuery query)
		{
			var bookById = await _bookRepository.GetByIdAsync(query.Id);

			if (bookById == null)
			{
				throw new KeyNotFoundException($"Book with Id {query.Id} not found.");
			}

			return BookDTO.FromEntity(bookById);
		}
	}
}
