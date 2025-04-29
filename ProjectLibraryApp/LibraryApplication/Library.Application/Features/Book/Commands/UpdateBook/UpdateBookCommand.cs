namespace Library.Application.Features.Book.Commands.UpdateBook
{
	public record UpdateBookCommand(int Id, string Name, decimal Price, int Amount);
}
