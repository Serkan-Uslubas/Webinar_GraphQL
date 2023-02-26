using DF.Webinar.GraphQL.Api.Mutations;
using DF.Webinar.GraphQL.Api.Queries;
using DF.Webinar.GraphQL.Database;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Data;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Server=(localdb)\\mssqllocaldb;Database=graphqldb-local;Trusted_Connection=Yes;";
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
    opt.EnableSensitiveDataLogging();
});

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType<BookQueries>()
    .AddMutationType<BookMutations>()
    .SetPagingOptions(new PagingOptions
        {
            MaxPageSize = 100
        })
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

app.UsePlayground()
    .UseVoyager();

app.MapGraphQL();


