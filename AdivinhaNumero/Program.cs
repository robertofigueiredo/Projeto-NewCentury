using Domain.Context;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ContextoJogo>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ConexaoSQLite"));
});
builder.Services.AddScoped<IServicesAdivinhaInteiro, ServicesAdivinhaInteiro>();
builder.Services.AddScoped<AdivinhaInteiroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdivinhaInteiro}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
