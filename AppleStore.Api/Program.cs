using AppleStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//the builder

app.MapApplesEndpoints();
//This defines the endpoint.


app.Run();
