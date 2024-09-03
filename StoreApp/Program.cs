using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Context;
using StoreApp.Data.Extensions;
using StoreApp.Extensions;
using StoreApp.Data.Repositories.Abstractions;
using StoreApp.Data.Repositories.Concretions;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Service.Services.Abstractions;
using StoreApp.Service.Services.Concretions;
using StoreApp.Service.Extensions;
using NToastNotify;
using StoreApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        ProgressBar = false,
    });
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
builder.Services.ConfigureRouting();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();




var app = builder.Build();
app.UseNToastNotify();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureAdminUser();

app.Run();
