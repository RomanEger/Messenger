using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Presentation.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.
    AddDebug().
    AddConsole();

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddAuthorization();

builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.MapHub<ChatHub>("/chat");  

app.Run();