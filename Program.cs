using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dotnet_newbie.Data;
using dotnet_newbie.Models;
var builder = WebApplication.CreateBuilder(args);

// Use SQL Server
// builder.Services.AddDbContext<dotnet_newbieContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("dotnet_newbieContext") ?? throw new InvalidOperationException("Connection string 'dotnet_newbieContext' not found.")));

// Postgresql Server
builder.Services.AddDbContext<dotnet_newbieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string for Postgresql is not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
