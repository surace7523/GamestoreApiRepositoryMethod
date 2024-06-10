using Gamestore.Api.Entities;

namespace GameStore;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";


    static List<Game> games = new(){
                              new Game(){
        Id = 1,
        Name = "Street fighter",


        Genre = "Fighting",


        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUrl ="https://placeholder.co/100:"
    },
 new Game(){
        Id = 2,
        Name = "Teken3",


        Genre = "Fighting",


        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUrl ="https://placeholder.co/100:"
    },
    new Game(){
        Id = 3,
        Name = "Mario Brothers",


        Genre = "Fighting",


        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUrl ="https://placeholder.co/100:"
    },
     new Game(){
        Id = 4,
        Name = "GTA 7",


        Genre = "Fighting",


        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUrl ="https://placeholder.co/100:"
    }};
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
                .WithParameterValidation();

        //get api
        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);

            if (game is null)
            {

                return Results.NotFound();
            }


            return Results.Ok(game);


        })
        .WithName("GetGame");

        //post api
        group.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);


            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

        });


        //update api
        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = games.Find(game => game.Id == id);

            if (existingGame is null)
            {

                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUrl = updatedGame.ImageUrl;

            return Results.NoContent();

        });

        //delete api
        group.MapDelete("/{id}", (int id) =>
        {


            Game? game = games.Find(game => game.Id == id);

            if (game is not null)
            {

                games.Remove(game);
            }



            return Results.NoContent();
        });

        return group;
    }

}
