namespace Library.Domain.Entities
{
	public class Book
	{
		public int Id { get; private set; }
		public string Name { get; private set; } = string.Empty;
		public decimal Price { get; private set; }
		public int Amount { get; private set; }

		public Book(string name, decimal price, int amount)
		{
			SetName(name);
			SetPrice(price);
			SetAmount(amount);
		}

		public void SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Book name cannot be empty.");
			Name = name;
		}

		public void SetPrice(decimal price)
		{
			if (price < 0)
				throw new ArgumentException("Price cannot be negative.");
			Price = price;
		}

		public void SetAmount(int amount)
		{
			if (amount < 0)
				throw new ArgumentException("Amount cannot be negative.");
			Amount = amount;
		}

		public void ReduceAmount(int qty)
		{
			if (qty <= 0 || qty > Amount)
				throw new InvalidOperationException("Invalid quantity to reduce.");
			Amount -= qty;
		}

		public void IncreaseAmount(int qty)
		{
			if (qty <= 0)
				throw new InvalidOperationException("Invalid quantity to increase.");
			Amount += qty;
		}

		public decimal CalculateTotalBorrowPrice(int qty)
		{
			if (qty <= 0 || qty > Amount)
				throw new InvalidOperationException("Invalid quantity.");
			return qty * Price;
		}
	}
}