namespace Library;

public class BookLoan
{
    public int BookLoanId { get; set; }
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool Status { get; set; }


    public Book Book { get; set; } = null!;
    public Borrower Borrower { get; set; } = null!;

}