using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sales.Web;
using Sales.Web.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7138//") });

builder.Services.AddScoped<IRepository, Repository>();
//scoped: quiero q me cree una nueva instancia del objeto cada vez q llamo inyeccion
//transient: lo inyecta solo una vez. 
//singleton: crea la isntancia y luego la llama repetidas veces. No recomendado

builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();
