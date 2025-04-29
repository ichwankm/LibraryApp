using Library.Domain.Entities;

namespace Library.Application.DTOs
{
	public class TransactionDTO
	{
		public int Id { get; set; }
		public string BookName { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public DateTime BorrowDate { get; set; }
		public DateTime? ReturnDate { get; set; }
		public bool IsCompleted { get; set; }

		public static TransactionDTO FromEntity(Transaction transaction)
		{
			return new TransactionDTO
			{
				Id = transaction.Id,
				BookName = transaction.Book.Name,
				UserName = transaction.User.Username,
				BorrowDate = transaction.BorrowDate,
				ReturnDate = transaction.ReturnDate,
				IsCompleted = transaction.IsCompleted
			};
		}
	}
}
