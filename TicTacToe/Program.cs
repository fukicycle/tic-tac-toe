using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using fukicycle.Blazor.Neumorphism.Design.Base;
using TicTacToe.Data;
using TicTacToe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<GridItemService>();
builder.Services.AddSingleton<Winner>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseNeumorphism(BaseColor.Parse("#E0E0E0"));

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
