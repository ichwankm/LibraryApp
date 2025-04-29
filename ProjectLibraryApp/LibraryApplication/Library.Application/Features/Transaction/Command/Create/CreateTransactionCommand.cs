namespace Library.Application.Features.Transaction.Command.Create
{
	public record CreateTransactionCommand(int bookId, int userId, DateTime borrowDate);
}
