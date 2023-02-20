namespace DF.Webinar.GraphQL.Models;

public class Book
{
    public Book()
    {
    }

    public int Id { get; set; }
    public int? YearOfPublication { get; set; }
    public string? ArticleNumber { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Isbn { get; set; }
    public string? Language { get; set; }
    public int? Pages { get; set; }
    public double? Price { get; set; }
    public long? AuthorId { get; set; }
    public Author? Author { get; set; }
}
