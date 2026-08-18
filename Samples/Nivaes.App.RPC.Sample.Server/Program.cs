using Nivaes.App.RPC.Sample.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddGrpc();
//builder.Services.AddHealthChecks();

var app = builder.Build();

//app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
//app.MapGet("/test", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGet("/test", () => "OK");

app.MapDefaultEndpoints();

app.Run();
