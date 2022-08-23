using  Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("Api/[Controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new List<Book>
        {
            new Book{
                Id = 0,
                Title = "Book 1",
                AuthorName = "Author 1",
                PublishDate = new DateTime(2011, 08, 11),
                ReviewDate = new DateTime(2013, 01, 10),         
                Price = 300,
            },
            new Book{
                Id = 1,
                Title = "Book 2",
                AuthorName = "Author 2",
                PublishDate = new DateTime(2010, 04, 01),
                ReviewDate = new DateTime(2011, 01, 10),         
                Price = 250,
            }

        };
    [HttpGet]
    public async Task<ActionResult<List<Book>>> Get() 
    {
        return Ok(books);
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return BadRequest("Book Not found.");
        return Ok(book);
    }
    [HttpPost]
    public async Task<ActionResult<Book>> Post(Book book)
    {
        books.Add(book);
        return Ok(book);
    }
}