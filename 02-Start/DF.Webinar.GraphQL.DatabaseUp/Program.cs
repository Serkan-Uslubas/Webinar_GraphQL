using DF.Webinar.GraphQL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=graphqldb-local;Trusted_Connection=Yes;";

using IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices(services =>
{
    services.AddDbContextFactory<DfContext>(opt =>
    {
        opt.UseSqlServer(ConnectionString);
        opt.EnableSensitiveDataLogging();
    });
})
.Build();



await host.RunAsync();