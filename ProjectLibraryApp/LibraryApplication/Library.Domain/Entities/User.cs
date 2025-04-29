namespace Library.Domain.Entities
{
	public class User
	{
		public int Id { get; private set; }
		public string Username { get; private set; } = string.Empty;

		public User(string username)
		{
			SetUsername(username);
		}

		public void SetUsername(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new ArgumentException("Username cannot be empty or null.");

			if (username.Length > 50)
				throw new ArgumentException("Username cannot exceed 50 characters.");

			Username = username;
		}
	}
}