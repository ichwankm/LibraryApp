using Library.Application.DTOs;
using Library.Application.Features.Transaction.Command.Complete;
using Library.Application.Features.Transaction.Command.Create;
using Library.Application.Features.Transaction.Command.Delete;
using Library.Application.Features.Transaction.Queries.GetAll;
using Library.Application.Features.Transaction.Queries.GetTransactionById;
using Library.Application.Interfaces.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly IAppMediator _mediator;

		public TransactionController(IAppMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllTransactionsQuery();
			var transactions = await _mediator.SendQuery<GetAllTransactionsQuery, List<TransactionDTO>>(query);
			return Ok(transactions);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetTransactionByIdQuery { Id = id };
			var transaction = await _mediator.SendQuery<GetTransactionByIdQuery, TransactionDTO>(query);
			return Ok(transaction);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
		{
			var transactionId = await _mediator.SendCommand<CreateTransactionCommand, int>(command);
			return CreatedAtAction(nameof(GetById), new { id = transactionId }, null);
		}

		[HttpPut("{id}/complete")]
		public async Task<IActionResult> Complete(int id, [FromBody] CompleteTransactionCommand command)
		{
			if (id != command.TransactionId)
				return BadRequest("Mismatched transaction ID");

			await _mediator.SendCommand<CompleteTransactionCommand, int>(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteTransactionCommand { Id = id };
			await _mediator.SendCommand<DeleteTransactionCommand, int>(command);
			return NoContent();
		}
	}
}
