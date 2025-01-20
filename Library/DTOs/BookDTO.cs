namespace Library.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Authors { get; set; }
}