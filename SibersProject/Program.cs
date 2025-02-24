using Data;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Services;
using SibersProject.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("mssql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(option => option.UseSqlServer(path));

builder.Services.AddScoped <IRepository<EmployeeDTO>, RepositoryEmployee>();

//builder.Services.AddScoped<ICommand<UserDTO>, RegistrationUserCommand>();

//builder.Services.AddScoped<IQueryService<All, List<UserDTO>>, AllUsersService>();

//builder.Services.AddScoped<IQueryService<SearchById, UserDTO>, GetUserByIdQuery>();

//builder.Services.AddScoped<ICommand<UpdateClient>, UpdateCommandService>();


var app = builder.Build();




app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages()
   .WithStaticAssets();

app.UseAuthorization();

app.MapStaticAssets();

app.Run();
