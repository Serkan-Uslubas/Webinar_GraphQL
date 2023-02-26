using DF.Webinar.GraphQL.Database;
using DF.Webinar.GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace DF.Webinar.GraphQL.Api.Queries
{
    public class BookQueries
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] AppDbContext context) => context.Books;

        [UseDbContext(typeof(AppDbContext))]
        [UseFirstOrDefault]
        [UseProjection]
        [UseFiltering]
        [UseDbContext(typeof(AppDbContext))]
        public Book GetBookById(int id, [ScopedService] AppDbContext context) => context.Books.Find(id);
    }
}
