namespace DF.Webinar.GraphQL.Models;

public class Author
{
    public Author()
    {
        Books = new List<Book>();
    }

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public virtual ICollection<Book> Books { get; set; }

}
