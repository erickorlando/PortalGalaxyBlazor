using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Services.Profiles;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PortalGalaxyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortalGalaxy"));
});

// Registramos las dependencias de Repositories y Services
builder.Services.Scan(selector => selector
    .FromAssemblies(typeof(ICategoriaRepository).Assembly,
        typeof(ICategoriaService).Assembly)
    .AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime()
);


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CategoriaProfile>();
    config.AddProfile<InstructorProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
