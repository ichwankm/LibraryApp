using Library.Application.DTOs;
using Library.Application.Features.User.Commands.CreateUser;
using Library.Application.Features.User.Commands.DeleteUser;
using Library.Application.Features.User.Commands.UpdateUser;
using Library.Application.Features.User.Queries.GetAllUsers;
using Library.Application.Features.User.Queries.GetUserById;
using Library.Application.Interfaces.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IAppMediator _mediator;

		public UserController(IAppMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllUsersQuery();
			var users = await _mediator.SendQuery<GetAllUsersQuery, List<UserDTO>>(query);
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetUserByIdQuery { Id = id };
			var user = await _mediator.SendQuery<GetUserByIdQuery, UserDTO>(query);
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
		{
			var userId = await _mediator.SendCommand<CreateUserCommand, int>(command);
			return CreatedAtAction(nameof(GetById), new { id = userId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
		{
			if (id != command.Id)
				return BadRequest("Mismatched user ID");

			await _mediator.SendCommand<UpdateUserCommand, int>(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteUserCommand { Id = id };
			await _mediator.SendCommand<DeleteUserCommand, int>(command);
			return NoContent();
		}
	}
}
