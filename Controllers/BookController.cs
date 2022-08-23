using  Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("Api/[Controller]")]
public class BookController : ControllerBase
{
    private static int AutoGeneratedId{get;set;} = 0;
    private static List<Book> books = new List<Book>
        {
            new Book{
                Id = ++AutoGeneratedId,
                Title = "Book 1",
                AuthorName = "Author 1",
                PublishDate = new DateTime(2011, 08, 11),
                ReviewDate = new DateTime(2013, 01, 10),         
                Price = 300,
            },
            new Book{
                Id = ++AutoGeneratedId,
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
        book.Id = ++AutoGeneratedId;
        books.Add(book);
        return Ok(book);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Book>> Put(int id, Book update)
    {
        var exist = books.Find(b => b.Id == id);
        if (exist == null)
            return NotFound("Book does not exist!");
        else 
        {
            exist.Title = update.Title;
            exist.AuthorName = update.AuthorName;
            exist.PublishDate = update.PublishDate;
            exist.ReviewDate = update.ReviewDate;
            exist.Price = update.Price;
            return Ok(update);
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Book>> Delete(int id)
    {
        var exist = books.FirstOrDefault(b => b.Id == id);
        if (exist != null)
        {
            books.Remove(exist);
            return Ok(exist);
        }
        return NotFound("Book does not found.");
    }
}