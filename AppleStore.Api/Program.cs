using AppleStore.Api.Endpoints;
using AppleStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IApplesRepository, InMemApplesRepository>();

var app = builder.Build();
//the builder

app.MapApplesEndpoints();
//This defines the endpoint.


app.Run();
