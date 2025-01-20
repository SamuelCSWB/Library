namespace Library;

public class Borrower
{
    public int BorrowerId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;

    public ICollection<BookLoan> Loans { get; set; } = new List<BookLoan>();
}