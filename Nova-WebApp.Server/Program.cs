using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nova_WebApp.Server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Nova_WebAppServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Nova_WebAppServerContext") ?? throw new InvalidOperationException("Connection string 'Nova_WebAppServerContext' not found.")));

// Add services to the container.
builder.Services.AddControllers(); // es el predeterminado pero lo comento para anadir el de abajo
//builder.Services.AddControllersWithViews(); //nuevo, lo quite porque no quiero usar views
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Regristrando AutoMapper: buscara todas las clases que hereden de Profile en los ensamblajes cargados y las registrara automaticamente

var app = builder.Build();

//app.UseDefaultFiles();// lo comente, sirvio pero si surgen problemas probar quitarlo. es para no ejecuta react. luego lo use para las views pero lo quite nuevamente
//app.UseStaticFiles();// lo comente, sirvio pero si surgen problemas probar quitarlo. es para no ejecuta react.luego lo use para las views pero lo quite nuevamente

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("AllowReactDevOrigin"); // nuevo, no tocar, se supone que para conectar con react

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Users}/{action=Index}/{id?}"); // nuevo, Configuración de home como la ruta por defecto. Lo quite porque no quiero usar views

//app.MapFallbackToFile("/index.html"); // lo comente, sirvio pero si surgen problemas probar quitarlo. es para no ejecuta react

app.Run();

//builder.Services.AddCors(options => // nuevo, no tocar
//{
//    options.AddPolicy("AllowReactDevOrigin",
//        builder => builder.WithOrigins("http://localhost:3000") // puerto de React
//                           .AllowAnyHeader()
//                           .AllowAnyMethod());
//});

//...

//app.UseCors("AllowReactDevOrigin");
