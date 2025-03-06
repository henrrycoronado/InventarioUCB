using ServicesApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventarioUcbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))
    )
);

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<SolicitudPrestamoRepository>();
builder.Services.AddScoped<ReporteRepository>();
builder.Services.AddScoped<RegistroActividadesRepository>();
builder.Services.AddScoped<PrestamoRepository>();
builder.Services.AddScoped<EquipoRepository>();
builder.Services.AddScoped<DetalleSolicitudPrestamoRepository>();
builder.Services.AddScoped<ComponenteRepository>();
builder.Services.AddScoped<CategoriaRepository>();

builder.Services.AddScoped<ValidacionesService>();
builder.Services.AddScoped<ILoginService, LoginServices>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<INotificacionService, NotificacionService>();
builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IComponentService, ComponenteService>();
builder.Services.AddScoped<IGestionarSolicitudService, GestionarSolicitudService>();
builder.Services.AddScoped<IPrestamoService, PrestamoService>();
builder.Services.AddScoped<ISolicitudPrestamoService, SolicitudPrestamoService>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();

builder.Services.AddSingleton<LoginData>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
