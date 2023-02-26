using DF.Webinar.GraphQL.Database;
using DF.Webinar.GraphQL.Models;
using HotChocolate.Data;
using HotChocolate;

namespace DF.Webinar.GraphQL.Api.Mutations
{
    public class BookMutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Book> AddBookAsync(Book book, [ScopedService] AppDbContext context)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Book> UpdateBookAsync(int id, Book book, [ScopedService] AppDbContext context)
        {
            var oldBook = context.Books.Find(id);
            if (oldBook == null)
            {
                throw new GraphQLException("Book not found");
            }

            oldBook.YearOfPublication = book.YearOfPublication;
            oldBook.ArticleNumber = book.ArticleNumber;
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.Isbn = book.Isbn;
            oldBook.Language = book.Language;
            oldBook.Pages = book.Pages;
            oldBook.Price = book.Price;
            oldBook.AuthorId = book.AuthorId;

            await context.SaveChangesAsync();
            return oldBook;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Book> DeleteBookAsync(int id, [ScopedService] AppDbContext context)
        {
            var book = context.Books.Find(id);
            if (book == null)
            {
                throw new GraphQLException("Book not found");
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}