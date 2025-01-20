using Library.Controllers;

namespace Library.DTOs;

public static class DTOExtensions
{
    public static Book ToBook(this CreateBookDTO createBookDTO)
    {
            
            
        return new Book
        {
            Title = createBookDTO.Title,
            Isbn = createBookDTO.Isbn,
            ReleaseYear = createBookDTO.ReleaseYear,
            Authors = new List<Author>()
                
        };
            
    }

    public static BookDTO ToBookDTO(this Book book)
    {
        return new BookDTO()
        {
            Id = book.BookId,
            Title = book.Title,

            Authors = book.Authors.ToStringAuthor()


        };
    }

    public static BookDetailsDTO ToBookDetailsDTO(this Book book)
    {
        return new BookDetailsDTO()
        {
            BookId = book.BookId,
            Title = book.Title,
            Isbn = book.Isbn,
            ReleaseYear = book.ReleaseYear,
            Authors = book.Authors.ToStringAuthor(),
            Status = book.CheckedOut ?  "Checked out" : "Available"

        };
    }

    public static Author ToAuthor(this CreateAuthorDTO createAuthorDTO)
    {
        return new Author()
        {
            Firstname = createAuthorDTO.Firstname,
            Lastname = createAuthorDTO.Lastname
        };
    }

    public static string ToStringAuthor(this IEnumerable<Author> authors)
    {
        return string.Join(", ", authors.Select(author => $"{author.Firstname} {author.Lastname}"));

    }

    public static Borrower ToBorrower(this CreateBorrowerDTO createBorrowerDto)
    {
        return new Borrower()
        {
            Firstname = createBorrowerDto.Firstname,
            Lastname = createBorrowerDto.Lastname
        };
    }

    public static BookLoan ToBookLoan(this CreateLoanDTO createLoanDTO)
    {
        return new BookLoan()
        {
            BookId = createLoanDTO.BookId,
            BorrowerId = createLoanDTO.BorrowerId,
            LoanDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            ReturnDate = DateTime.Now.AddDays(28).ToString("yyyy - MM - dd HH: mm:ss"),
            CheckedOut = true

        };
    }


}