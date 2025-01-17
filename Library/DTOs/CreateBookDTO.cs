
namespace Library.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; } = null!;
        public int Isbn { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<CreateAuthorDTO> Authors { get; set; } = new List<CreateAuthorDTO>();
    }


    public class CreateLoanDTO
    {
        public int BorrowerId { get; set; }
        public int BookId { get; set; }

    }

    public static class DTOExtensions
    {
        public static Book ToBook(this CreateBookDTO createBookDTO)
        {
            
            
            return new Book
            {
                Title = createBookDTO.Title,
                Isbn = createBookDTO.Isbn,
                ReleaseDate = createBookDTO.ReleaseDate,
                Authors = new List<Author>()
                
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
        public static BookLoan ToBookLoan(this CreateLoanDTO dto)
        {
            return new BookLoan
            {
                BorrowerId = dto.BorrowerId,
                BookId = dto.BookId,
                LoanDate = DateTime.Now,
            };
        }
    }



}
