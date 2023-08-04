using Microsoft.EntityFrameworkCore;
using ProyectoGestionVenta.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var conectionString = builder.Configuration.GetSection("AppSettings")["EnProduccion"].Equals("SI") ? builder.Configuration.GetConnectionString("pro") : builder.Configuration.GetConnectionString("dev");

builder.Services.AddDbContext<GestionVentasContext>(option =>
    option.UseSqlServer(conectionString),
    ServiceLifetime.Scoped
);
var app = builder.Build();

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
