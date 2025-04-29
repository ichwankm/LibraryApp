using Library.Application.DTOs;
using Library.Application.Features.Book.Commands.CreateBook;
using Library.Application.Features.Book.Commands.DeleteBook;
using Library.Application.Features.Book.Commands.UpdateBook;
using Library.Application.Features.Book.Queries.GetAllBooks;
using Library.Application.Features.Book.Queries.GetBookById;
using Library.Application.Interfaces.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IAppMediator _mediator;

		public BookController(IAppMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllBooksQuery();
			var books = await _mediator.SendQuery<GetAllBooksQuery, List<BookDTO>>(query);
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById(int id)
		{
			var query = new GetBookByIdQuery { Id = id };
			var book = await _mediator.SendQuery<GetBookByIdQuery, BookDTO>(query);
			return Ok(book);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
		{
			var bookId = await _mediator.SendCommand<CreateBookCommand, int>(command);
			return CreatedAtAction(nameof(GetBookById), new { id = bookId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command)
		{
			if (id != command.Id)
				return BadRequest("Mismatched book ID");

			await _mediator.SendCommand<UpdateBookCommand, int>(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteBookCommand { Id = id };
			await _mediator.SendCommand<DeleteBookCommand, int>(command);
			return NoContent();
		}
	}
}
