using Microsoft.EntityFrameworkCore;
using UjinTemplateServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString));

});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseRouting();

app.Run();
