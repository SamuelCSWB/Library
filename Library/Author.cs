namespace Library;

public class Author
{
    public int AuthorId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;

    public ICollection<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
}