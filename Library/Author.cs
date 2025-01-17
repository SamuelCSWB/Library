namespace Library;

public class Author
{
    public int AuthorId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}