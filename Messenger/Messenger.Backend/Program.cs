using Messenger.Backend.Hubs;
using Messenger.Backend.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.
    AddDebug().
    AddConsole();

builder.Services.ConfigureJwtSettings(builder.Configuration);

builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddSignalR(); 

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");  

app.Run();