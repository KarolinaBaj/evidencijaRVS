using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.DAL;
using Microsoft.EntityFrameworkCore.SqlServer;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.BLL.Servicess;
using System.Runtime.InteropServices;
using Evidencija.DAL.Repozitorijumi;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EvidencijaDBcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<korisnikiservice, KorisnikService>();
builder.Services.AddScoped<Preglediservice, Pregledservices>();
builder.Services.AddScoped<KorisnikRepozitorijum>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();
