namespace Library;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public int Isbn { get; set; }
    public DateTime ReleaseDate { get; set; } 

    public ICollection<Author> Authors { get; set; } = new List<Author>();
    public ICollection<BookLoan> BookLoan { get; set; } = new List<BookLoan>();

}