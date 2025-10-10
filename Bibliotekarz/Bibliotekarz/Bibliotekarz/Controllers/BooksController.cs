using Bibliotekarz.Common.CommunicationModel;
using Bibliotekarz.Data.Context;
using Bibliotekarz.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public BooksController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    // localhost/Books/Get
    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    {
        // LINQ
        List<BookDto> result = await dbContext.Books.Where(book => book.PageCount > 0).Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title, 
            Author = book.Author,
            PageCount = book.PageCount,
            IsBorrowed = book.IsBorrowed
        })
            .OrderBy(book => book.Author).ThenByDescending(book => book.Title)
            .ToListAsync();

        GetBooksResponse response = new GetBooksResponse
        {
            Books = result
        };
        return Ok(response);
    }

    // localhost/Books/Get/123
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var book = await dbContext.Books.Include(b => b.Borrower).FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
            return NotFound();

        BookDto response = new BookDto
        {
            Id = book.Id,
            Author = book.Author,
            PageCount = book.PageCount,
            IsBorrowed = book.IsBorrowed,
            BorrowerFirstName = book.Borrower?.FirstName,
            BorrowerLastName = book.Borrower?.LastName,
        };
        
        return Ok(response);
    }

    // localhost/Books/Add
    [HttpPost("[action]")]
    public async Task<IActionResult> Add(AddBookRequest request)
    {
        Book book = new Book
        {
            Author = request.Author,
            Title = request.Title,
            PageCount = request.PageCount,
            IsBorrowed = request.IsBorrowed
        };

        if (request.IsBorrowed)
        {
            book.Borrower = new Customer
            {
                FirstName = request.BorrowerFirstName,
                LastName = request.BorrowerLastName
            };
        }

        dbContext.Books.Add(book);
        await  dbContext.SaveChangesAsync();

        return Created();
    }

    // localhost/Books/Update
    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateBookRequest request)
    {
        Book updatedBook = dbContext.Books.FirstOrDefault(b => b.Id == request.Id);

        if (updatedBook == null)
            return NotFound("Nie znaleziono rekordu");

        updatedBook.Author = request.Author;
        updatedBook.Title = request.Title;
        updatedBook.PageCount = request.PageCount;
        updatedBook.IsBorrowed = request.IsBorrowed;
        updatedBook.Author = request.Author;

        if (updatedBook.IsBorrowed)
        {
            updatedBook.Borrower = new Customer
            {
                FirstName = request.BorrowerFirstName,
                LastName = request.BorrowerLastName
            };
        }

        dbContext.Books.Update(updatedBook);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}

