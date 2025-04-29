using Library.Domain.Entities;

namespace Library.Application.DTOs
{
	public class BookDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Amount { get; set; }

		public static BookDTO FromEntity(Book book)
		{
			return new BookDTO
			{
				Id = book.Id,
				Name = book.Name,
				Amount = book.Amount,
				Price = book.Price
			};
		}
	}
}
