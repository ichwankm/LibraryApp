namespace Library.Application.Features.Book.Commands.CreateBook
{
	public record CreateBookCommand(string Name, decimal Price, int Amount);
}