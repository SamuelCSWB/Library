using Microsoft.EntityFrameworkCore;

namespace Library;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }
}