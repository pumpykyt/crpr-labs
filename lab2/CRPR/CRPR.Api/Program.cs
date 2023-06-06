using CRPR.Api.Data;
using CRPR.Api.Interfaces;
using CRPR.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(a => a.UseNpgsql(connectionString, 
    b => b.MigrationsAssembly("CRPR.Api")));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();