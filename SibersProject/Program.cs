using Data;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Services;
using Domain.Queries;
using Domain.DTO.Employee;
using Domain.DTO.Project;
using Domain.Queries.Employee;
using Domain.Commands.Employee;
using Domain.Commands.Project;
using Domain.Queries.Project;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("mssql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(option => option.UseSqlServer(path));

builder.Services.AddScoped <IRepository<EmployeeDTO>, RepositoryEmployee>();
builder.Services.AddScoped <IRepository<ProjectDTO>, RepositoryProject>();

builder.Services.AddScoped <ICommandService<EmployeeDTO>, EmployeeAddCommand>();
builder.Services.AddScoped <ICommandService<ProjectDTO>, ProjectAddCommand>();

builder.Services.AddScoped <IQueryService<All, IEnumerable<EmployeeDTO>>, GetAllEmployeesQueryService>();
builder.Services.AddScoped <ICommandService<EmployeeUpdateDTO>, EmployeeUpdateCommand>();
builder.Services.AddScoped <ICommandService<EmployeeDeleteDTO>, EmployeeDeleteCommand>();
builder.Services.AddScoped <IQueryService<EmployeeSearchByIdDTO, EmployeeDTO>, GetByIdEmployeesQueryService>();


builder.Services.AddScoped <IQueryService<All, IEnumerable<ProjectDTO>>, GetAllProjectsQueryService>();
builder.Services.AddScoped <IQueryService<ProjectSearchByIdDTO, ProjectDTO>, GetByIdProjectQueryService>();
builder.Services.AddScoped <ICommandService<ProjectUpdateDTO>, ProjectUpdateCommand>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages()
   .WithStaticAssets();

app.UseAuthorization();

app.MapStaticAssets();

app.Run();
