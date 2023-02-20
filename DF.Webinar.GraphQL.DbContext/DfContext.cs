using DF.Webinar.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DF.Webinar.GraphQL.Database
{
    public class DfContext : DbContext
    {
        public DfContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}