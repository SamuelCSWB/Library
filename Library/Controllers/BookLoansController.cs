using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library;
using Library.DTOs;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookLoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookLoan>>> GetBookLoans()
        {
            return await _context.BookLoans.ToListAsync();
        }

        // GET: api/BookLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookLoan>> GetBookLoan(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            return bookLoan;
        }

        // PUT: api/BookLoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookLoan(int id)
        {
            var bookLoan = await _context.BookLoans
                .FirstOrDefaultAsync(bl => bl.BookLoanId == id && bl.CheckedOut == true);

            if (bookLoan == null)
            {
                return NotFound("Book loan not found.");
            }


            bookLoan.CheckedOut = false;
            bookLoan.ReturnDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            

            _context.Entry(bookLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookLoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return NoContent();
        }

        // POST: api/BookLoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookLoan>> PostBookLoan(CreateLoanDTO createLoanDTO)
        {
            var book = await _context.Books.Include(b => b.BookLoans).FirstOrDefaultAsync(b => b.BookId == createLoanDTO.BookId);

            if (book == null)
            {
                return BadRequest("The book is not available");
            }

            if (book.BookLoans.Any(bl => bl.CheckedOut))
            {
                return BadRequest("The book is not available");
            }

            var borrower = await _context.Borrowers.FindAsync(createLoanDTO.BorrowerId);

            if (borrower == null)
            {
                return NotFound();
            }

            var bookLoan = createLoanDTO.ToBookLoan();
            
            _context.BookLoans.Add(bookLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookLoan", new { id = bookLoan.BookLoanId }, bookLoan);
        }

        // DELETE: api/BookLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookLoan(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            _context.BookLoans.Remove(bookLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookLoanExists(int id)
        {
            return _context.BookLoans.Any(e => e.BookLoanId == id);
        }
    }
}
