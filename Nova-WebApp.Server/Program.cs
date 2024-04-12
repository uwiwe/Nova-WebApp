using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nova_WebApp.Server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Nova_WebAppServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Nova_WebAppServerContext") ?? throw new InvalidOperationException("Connection string 'Nova_WebAppServerContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseDefaultFiles();// lo comente, sirvio pero si surgen problemas probar quitarlo. es para no ejecuta react
//app.UseStaticFiles();// lo comente, sirvio pero si surgen problemas probar quitarlo. es para no ejecuta react

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("AllowReactDevOrigin"); // nuevo, no tocar

app.UseAuthorization();

app.MapControllers();

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
