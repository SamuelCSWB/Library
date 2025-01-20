namespace Library;

public class BookLoan
{
    public int BookLoanId { get; set; }
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public string LoanDate { get; set; }
    public string ReturnDate { get; set; }
    public bool CheckedOut { get; set; }



    public Book Book { get; set; } = null!;
    public Borrower Borrower { get; set; } = null!;

}