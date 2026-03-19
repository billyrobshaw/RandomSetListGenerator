using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicApp.UI2.Services;
using MusicAppUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



// Register HttpClient and your service

//When in Release
//builder.Services.AddScoped(sp => new HttpClient
//{
//    BaseAddress = new Uri("http://192.168.0.164:5000/")
//});

//Change when in Debug
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7169/")
    }); // your API URL


builder.Services.AddScoped<MusicService>();
builder.Services.AddScoped<BlazorTimer>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
