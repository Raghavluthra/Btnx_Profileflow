using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BtnxProfileApp;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");  // Ensure the App component exists and the ID is correct
builder.RootComponents.Add<HeadOutlet>("head::after");  // Ensure the HeadOutlet component is available

// Configure HttpClient to communicate with the Web API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5057/") });

await builder.Build().RunAsync();
