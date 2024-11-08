using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Presentation;
using Presentation.Hubs;
using Presentation.OptionsSetup;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddDbContext(builder.Configuration.GetConnectionString("DataBase") ?? throw new ArgumentException("DataBase connection string is null"))
    .AddPresentation();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader());

app.MapHub<ChatHub>("/chat");

app.MapControllers();

app.Map("/", (context) =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();