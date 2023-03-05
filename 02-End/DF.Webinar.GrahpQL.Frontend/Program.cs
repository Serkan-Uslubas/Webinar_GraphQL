using DF.Webinar.GrahpQL.Frontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

builder.Services
    .AddgraphClient()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7250/graphql/"))
    .ConfigureWebSocketClient(c => c.Uri = new Uri("wss://localhost:7250/graphql/"));


await builder.Build().RunAsync();
