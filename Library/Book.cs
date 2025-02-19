namespace Library;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public string Isbn { get; set; } = null!;
    public int ReleaseYear { get; set; }
    //public bool CheckedOut { get; set; }

    public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
    public ICollection<Author> Authors { get; set; } = new List<Author>();

}