namespace LibraryApi;
public class Book
{
    public Guid Id {get; set;}
    public string Title {get; set;}
    public string AuthorName {get; set;}
    public DateTime PublishDate {get; set;}
    public DateTime ReviewDate {get; set;}
    public double Price {get; set;}
}