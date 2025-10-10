using Bibliotekarz.Common.CommunicationModel;
using Bibliotekarz.Data.Context;
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

        return Ok();
    }

    // localhost/Books/Add
    [HttpPost("[action]")]
    public async Task<IActionResult> Add()
    {
        return Created();

    }
}

