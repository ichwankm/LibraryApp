using Library.Application.DTOs;
using Library.Application.Features.Book.Commands.CreateBook;
using Library.Application.Features.Book.Commands.DeleteBook;
using Library.Application.Features.Book.Commands.UpdateBook;
using Library.Application.Features.Book.Queries.GetAllBooks;
using Library.Application.Features.Book.Queries.GetBookById;
using Library.Application.Features.Transaction.Command.Complete;
using Library.Application.Features.Transaction.Command.Create;
using Library.Application.Features.Transaction.Command.Delete;
using Library.Application.Features.Transaction.Queries.GetAll;
using Library.Application.Features.Transaction.Queries.GetTransactionById;
using Library.Application.Features.User.Commands.CreateUser;
using Library.Application.Features.User.Commands.DeleteUser;
using Library.Application.Features.User.Commands.UpdateUser;
using Library.Application.Features.User.Queries.GetAllUsers;
using Library.Application.Features.User.Queries.GetUserById;
using Library.Application.Interfaces.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// Register Book Command and Query
			services.AddScoped<ICommandHandler<CreateBookCommand, int>, CreateBookCommandHandler>();
			services.AddScoped<ICommandHandler<UpdateBookCommand, int>, UpdateBookCommandHandler>();
			services.AddScoped<ICommandHandler<DeleteBookCommand, int>, DeleteBookCommandHandler>();

			services.AddScoped<IQueryHandler<GetBookByIdQuery, BookDTO>, GetBookByIdQueryHandler>();
			services.AddScoped<IQueryHandler<GetAllBooksQuery, List<BookDTO>>, GetAllBooksByQueryHandler>();

			// Register User Command and Query
			services.AddScoped<ICommandHandler<CreateUserCommand, int>, CreateUserCommandHandler>();
			services.AddScoped<ICommandHandler<UpdateUserCommand, int>, UpdateUserCommandHandler>();
			services.AddScoped<ICommandHandler<DeleteUserCommand, int>, DeleteUserCommandHandler>();

			services.AddScoped<IQueryHandler<GetUserByIdQuery, UserDTO>, GetUserByIdQueryHandler>();
			services.AddScoped<IQueryHandler<GetAllUsersQuery, List<UserDTO>>, GetAllUsersQueryHandler>();

			// Register Transaction Command and Query
			services.AddScoped<ICommandHandler<CreateTransactionCommand, int>, CreateTransactionCommandHandler>();
			services.AddScoped<ICommandHandler<CompleteTransactionCommand, int>, CompleteTransactionCommandHandler>();
			services.AddScoped<ICommandHandler<DeleteTransactionCommand, int>, DeleteTransactionCommandHandler>();

			services.AddScoped<IQueryHandler<GetTransactionByIdQuery, TransactionDTO>, GetTransactionByIdQueryHandler>();
			services.AddScoped<IQueryHandler<GetAllTransactionsQuery, List<TransactionDTO>>, GetAllTransactionsQueryHandler>();

			return services;
		}
	}
}
