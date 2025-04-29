namespace Library.Application.Features.Transaction.Command.Complete
{
	public record CompleteTransactionCommand(int TransactionId, DateTime ReturnDate);
}
