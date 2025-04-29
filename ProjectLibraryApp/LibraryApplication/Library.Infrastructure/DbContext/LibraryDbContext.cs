using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.DbContext
{
	public partial class LibraryDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
		{
		}

		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Book Entity
			modelBuilder.Entity<Book>()
				.ToTable("TblM_Book")
				.HasKey(b => b.Id);

			// User Entity
			modelBuilder.Entity<User>()
				.ToTable("TblM_User")
				.HasKey(u => u.Id);

			// Transaction Entity
			modelBuilder.Entity<Transaction>()
				.ToTable("TblT_Transaction")
				.HasKey(t => t.Id);

			// Relationship: Transaction -> Book
			modelBuilder.Entity<Transaction>()
				.HasOne(t => t.Book)
				.WithMany()
				.HasForeignKey(t => t.BookId)
				.OnDelete(DeleteBehavior.Restrict); // optional: prevent cascading deletes

			// Relationship: Transaction -> User
			modelBuilder.Entity<Transaction>()
				.HasOne(t => t.User)
				.WithMany()
				.HasForeignKey(t => t.UserId)
				.OnDelete(DeleteBehavior.Restrict); // optional: prevent cascading deletes
		}
	}
}