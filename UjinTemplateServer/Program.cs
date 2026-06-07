using Microsoft.EntityFrameworkCore;
using UjinTemplateServer.Common;
using UjinTemplateServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString));

});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:8080", "http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddScoped<HelperService>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

app.UseRouting();

app.UseCors("AllowFrontend");

app.MapControllers();

app.MapHub<ScreenHub>("/screenAuthentificate");

using (var helpik = app.Services.CreateScope())
{
    var sync = helpik.ServiceProvider.GetRequiredService<HelperService>();

    await sync.SyncBuildingsAsync();
}

app.Run();
