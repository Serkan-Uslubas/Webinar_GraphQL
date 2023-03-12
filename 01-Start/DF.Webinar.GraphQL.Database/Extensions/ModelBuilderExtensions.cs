using DF.Webinar.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DF.Webinar.GraphQL.Database.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "Martin", LastName = "Fowler" },
            new Author { Id = 2, FirstName = "Robert C.", LastName = "Martin" },
            new Author { Id = 3, FirstName = "Erich", LastName = "Gamma" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, AuthorId = 1, Title = "Refactoring", Description = "Improving the Design of Existing Code", YearOfPublication = 2018 },
            new Book { Id = 2, AuthorId = 1, Title = "NoSQL Distilled", Description = "A Brief Guide to the Emerging World of Polyglot Persistence", YearOfPublication = 2012 },
            new Book { Id = 3, AuthorId = 1, Title = "Domain Specific Languages", Description = "A detailed guide on implementing both internal and external DSLs", YearOfPublication = 2010 },
            new Book { Id = 4, AuthorId = 1, Title = "Patterns of Enterprise Application Architecture", Description = "By Martin Fowler, with Dave Rice, Matthew Foemmel, Edward Hieatt, Robert Mee, and Randy Stafford", YearOfPublication = 2002 },
            new Book { Id = 5, AuthorId = 1, Title = "Planning Extreme Programming", Description = "Now there are quite a few XP and agile books out there, many of which focus on planning and project management issues.", YearOfPublication = 2000 },
            new Book { Id = 6, AuthorId = 1, Title = "Analysis Patterns", Description = "The patterns come from various domains, including health care, financial trading, and accounting.", YearOfPublication = 1996 },
            new Book { Id = 7, AuthorId = 1, Title = "UML Distilled", Description = "A Brief Guide to the Standard Object Modeling Language", YearOfPublication = 2003 },
            new Book { Id = 8, AuthorId = 2, Title = "Designing Object-Oriented C++", Description = "Applications Using the Booch Method", YearOfPublication = 1995 },
            new Book { Id = 9, AuthorId = 2, Title = "Agile Software Development", Description = "Principles, Patterns, and Practices.", YearOfPublication = 2002 },
            new Book { Id = 10, AuthorId = 2, Title = "Clean Code", Description = "A Handbook of Agile Software Craftsmanship", YearOfPublication = 2009 },
            new Book { Id = 11, AuthorId = 2, Title = "Clean Architecture", Description = " A Craftsman's Guide to Software Structure and Design", YearOfPublication = 2017 },
            new Book { Id = 12, AuthorId = 2, Title = "Clean Agile", Description = "Back to Basics", YearOfPublication = 2019 },
            new Book { Id = 13, AuthorId = 3, Title = "Design Patterns", Description = "Elements of Reusable Object-Oriented Software", YearOfPublication = 1997 }
        );
    }
}
