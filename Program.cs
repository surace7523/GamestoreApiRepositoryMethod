
using GameStore;
using System.ComponentModel;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();

Adding 2nd change
Adding 1