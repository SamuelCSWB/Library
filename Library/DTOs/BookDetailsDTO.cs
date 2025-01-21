namespace Library.DTOs;

public class BookDetailsDTO
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public required string Isbn { get; set; }
    public int ReleaseYear { get; set; }
    public required string Authors { get; set; }
    public required string Status { get; set; }
    public string? ReturnDate { get; set; }

}