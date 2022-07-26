using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using MyFirstServerSideBlazor.Authentification;
using MyFirstServerSideBlazor.Authentification.Contracts;
using MyFirstServerSideBlazor.Database;
using MyFirstServerSideBlazor.Servises;
using MyFirstServerSideBlazor.Servises.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddMvcCore(options => options.EnableEndpointRouting = false);

var secret = builder.Configuration.GetValue<string>("Secret");

builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProviderServise>();
builder.Services.AddScoped<ICryptographyServise, CryptographyServise>();
builder.Services.AddDbContext<WebDatabaseContext>();
builder.Services.AddScoped<IUserServise, UserServise>();
builder.Services.AddScoped<IAccessTokenServise, AccessTokenServise>();
builder.Services.AddScoped<IBookServise, BookServise>();
builder.Services.AddScoped<ILoggerServise, LoggerServise>();
builder.Services.AddScoped<IBookCoverGeneratorServise, BookCoverGeneratorServise>();
builder.Services.AddSingleton<FontService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<IEmailServise, EmailServise>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseMvcWithDefaultRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
