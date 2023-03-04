using DF.Webinar.GraphQL.Database;
using DF.Webinar.GraphQL.Models;

namespace DF.Webinar.GraphQL.Api.Queries {
    public class BookQueries {
        
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] AppDbContext context) => context.Books;

        [UseFirstOrDefault]
        [UseProjection]
        [UseFiltering]
        public Book GetBookById(int id, [ScopedService] AppDbContext context) => context.Books.Find(id);
    }
}