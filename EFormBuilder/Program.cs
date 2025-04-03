// Path: EFormBuilder/Program.cs
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EFormBuilder.Services;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddSingleton<IFormService, InMemoryFormService>();
builder.Services.AddScoped<IBaseUrlService, BaseUrlService>();

// Configure base path for IIS deployment
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();