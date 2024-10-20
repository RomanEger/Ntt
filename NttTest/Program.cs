using Microsoft.EntityFrameworkCore;
using NttTest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NttDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
        opt => opt.MigrationsHistoryTable("Migrations", "migration")));

var app = builder.Build();

app.MapDefaultEndpoints();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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