using Library.Domain.Entities;

namespace Library.Application.DTOs
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string UserName { get; set; } = string.Empty;

		public static UserDTO FromEntity(User user)
		{
			return new UserDTO
			{
				Id = user.Id,
				UserName = user.Username
			};
		}
	}
}
