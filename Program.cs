using Ejmmaa.Data;
using Ejmmaa.Services.Interfaces;
using Ejmmaa.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration); // Registering the configuration instance as a singleton
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


builder.Services.AddScoped<DbHelper>(); 
builder.Services.AddScoped<Helper>(); 
builder.Services.AddScoped<IAdminsService, AdminsService>();
builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();
builder.Services.AddScoped<ISupervisorsService, SupervisorsService>();
builder.Services.AddScoped<IVotersService, VotersService>();
builder.Services.AddScoped<IMembersService,MembersService>(); 
builder.Services.AddScoped<ISectionsService,SectionsService>(); 

var app = builder.Build();

// Middleware Setup

app.UseSession(); 

app.UseStaticFiles(); 

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
