using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.InterfaceRepos;
using Ristorante.RepositoryEF;
using Ristorante.RepositoryEF.RepositoryEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Config DI
builder.Services.AddScoped<IBusinessLayer, MainBusinessLayer>();
builder.Services.AddScoped<IRepositoryMenu, RepositoryMenuEF>();
builder.Services.AddScoped<IRepositoryPiatti, RepositoryPiattiEF>();
builder.Services.AddScoped<IRepositoryUtenti, RepositoryUtentiEF>();


builder.Services.AddDbContext<MasterContext>(options =>
{
    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RistoranteDaBeppe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    option =>
    {
        option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
        option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adm", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
