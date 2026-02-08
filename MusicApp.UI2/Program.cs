using MusicApp.UI2.Components;
using MusicApp.UI2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Components services
builder.Services.AddRazorComponents();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

// Register HttpClient and your service
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7169/") }); // your API URL
builder.Services.AddScoped<MusicService>();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapStaticAssets();

// Map root app (replaces _Host.cshtml)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.UseAntiforgery();

app.Run();