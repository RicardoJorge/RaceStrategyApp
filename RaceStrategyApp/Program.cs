using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RaceStrategyApp;
using RaceStrategyApp.Services.Implementations;
using RaceStrategyApp.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IFuelCalculatorService, FuelCalculatorService>();
builder.Services.AddSingleton<IStintCaluclatorService, StintCalculatorService>();

await builder.Build().RunAsync();
