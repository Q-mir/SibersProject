using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("mssql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(option => option.UseSqlServer(path));

var app = builder.Build();




app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages()
   .WithStaticAssets();

app.UseAuthorization();

app.MapStaticAssets();

app.Run();
