using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();



app.UseCors(x => x.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();
