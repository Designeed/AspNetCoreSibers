using AspNetCoreSibers.Domain;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSibers.Domain.Repositories.EmployeeRepository;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
    services.AddScoped<IProjectRepository, EFProjectRepository>();
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Project}/{action=List}/{id?}");

app.Run();