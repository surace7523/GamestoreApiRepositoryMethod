
using GameStore;
using System.ComponentModel;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
AddingNewEventArgs 2