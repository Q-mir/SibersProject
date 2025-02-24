using Data;
using Domain.DTO;
using Domain.Repository;
using Domain.Commands;
using Microsoft.EntityFrameworkCore;
using Services;
using SibersProject.Model;
using Domain.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("mssql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(option => option.UseSqlServer(path));

builder.Services.AddScoped <IRepository<EmployeeDTO>, RepositoryEmployee>();
builder.Services.AddScoped <IRepository<ProjectDTO>, RepositoryProject>();
builder.Services.AddScoped <ICommandService<EmployeeDTO>, EmployeeAddCommand>();
builder.Services.AddScoped <ICommandService<ProjectDTO>, ProjectAddCommand>();

builder.Services.AddScoped<IQueryService<All, IEnumerable<EmployeeDTO>>, GetAllEmployeesQuery>();

var app = builder.Build();




app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages()
   .WithStaticAssets();

app.UseAuthorization();

app.MapStaticAssets();

app.Run();
