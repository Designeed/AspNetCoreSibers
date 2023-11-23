using AspNetCoreSibers.Domain;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSibers.Domain.Repositories.EmployeeRepository;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using AspNetCoreSibers.Service.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
    services.AddScoped<IProjectRepository, EFProjectRepository>();
    services.AddSingleton<TagHelperService>();

    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connection));

    services.AddControllersWithViews();
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
    app.UseHttpsRedirection();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Project}/{action=Index}/{id?}");

app.Run();