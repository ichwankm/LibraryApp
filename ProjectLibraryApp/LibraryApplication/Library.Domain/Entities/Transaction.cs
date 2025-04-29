using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	public class Transaction
	{
		public int Id { get; private set; }
		public int BookId { get; private set; }
		public virtual Book Book { get; private set; } = null!;
		public int UserId { get; private set; }
		public virtual User User { get; private set; } = null!;
		public DateTime BorrowDate { get; private set; }
		public DateTime? ReturnDate { get; private set; }
		public bool IsCompleted { get; private set; }

		public Transaction(int bookId, int userId, DateTime borrowDate)
		{
			BookId = bookId;
			UserId = userId;
			BorrowDate = borrowDate;
			IsCompleted = false;
		}

		public void CompleteTransaction(DateTime returnDate)
		{
			if (IsCompleted)
				throw new InvalidOperationException("Transaction is already completed.");

			if (returnDate < BorrowDate)
				throw new InvalidOperationException("Return date cannot be earlier than borrow date.");

			ReturnDate = returnDate;
			IsCompleted = true;
		}
	}
}