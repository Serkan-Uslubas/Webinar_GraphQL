using DF.Webinar.GraphQL.Api.Queries;
using DF.Webinar.GraphQL.Database;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => {
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    opt.EnableSensitiveDataLogging();
});


builder.Services.AddCors(options => {
    options.AddPolicy("DevCorsPolicy", builder => {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType<BookQueries>()
    .SetPagingOptions(new PagingOptions {
        IncludeTotalCount = true,
        DefaultPageSize = 10,
        MaxPageSize = 10000
    })
    .AddFiltering()
    .AddSorting()
    .AddProjections();

// Configure the HTTP request pipeline.

var app = builder.Build();

app.UseCors("DevCorsPolicy");

app.MapGraphQL();

app.Run();