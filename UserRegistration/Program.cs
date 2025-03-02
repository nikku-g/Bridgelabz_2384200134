using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using RepositoryLayer.Context;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<UserRegistrationBL>();
builder.Services.AddScoped<UserRegistrationRL>();

builder.Logging.ClearProviders(); 
/*builder.Logging.AddConsole(); 
builder.Logging.AddDebug();*/
builder.Host.UseNLog();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<UserRegistrationContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
