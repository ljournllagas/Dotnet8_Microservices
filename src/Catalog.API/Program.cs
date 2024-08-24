using Catalog.API;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// configure the HTTP request pipeline.
app.MapCarter();

app.Run();
