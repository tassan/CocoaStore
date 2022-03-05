using CocoaStore.Vendas.Api.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();