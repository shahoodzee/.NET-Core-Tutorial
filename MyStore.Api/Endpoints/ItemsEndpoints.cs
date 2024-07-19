namespace MyStore.Api.Endpoints;
using MyStore.Api.Dtos;

public static class ItemsEndpoints
{
    const string GetItemEndpointName = "GetItem";
    private static readonly List<ItemDto> items = new List<ItemDto>
    {
        new ItemDto(
            Id: 1,
            Name: "The Legend of Zelda: Breath of the Wild",
            Type: "Game",
            Description: "An open-world adventure game set in the Zelda universe.",
            Price: 59.99m,
            ReleaseDate: new DateOnly(2017, 3, 3)
        ),
        new ItemDto(
            Id: 2,
            Name: "Super Mario Odyssey",
            Type: "Game",
            Description: "A 3D platformer featuring Mario on a globe-trotting adventure.",
            Price: 49.99m,
            ReleaseDate: new DateOnly(2017, 10, 27)
        ),
        new ItemDto(
            Id: 3,
            Name: "Animal Crossing: New Horizons",
            Type: "Game",
            Description: "A life simulation game where players can create and manage their own island.",
            Price: 59.99m,
            ReleaseDate: new DateOnly(2020, 3, 20)
        )
    };

    //since we use RouteGroupBuilder now we dont have to explicitly write items keyword in our route 
    public static RouteGroupBuilder MapItemsEndpoints(this WebApplication app){

        //since all the routes are for the item resource we can hardcode the route like this:
        var group = app.MapGroup("items");
        
        group.MapGet("/", () => items);

        group.MapGet("/{id}", (int id) => {

            ItemDto? item = items.Find(item => item.Id == id);
            return item is null ? Results.NotFound() : Results.Ok(item);

        }).WithName(GetItemEndpointName);

        group.MapPost("/", (CreateItemDto newItem) => {
            ItemDto item = new (
                items.Count+1,
                newItem.Name,
                newItem.Type,
                newItem.Description,
                newItem.Price,
                newItem.ReleaseDate
            );
            items.Add(item);
            return Results.CreatedAtRoute(GetItemEndpointName, new { id = item.Id }, item);
        }).WithParameterValidation();
        //this function from the MinimalApi.Extensions package works the same as (ModelState.Isvalid ?) in ASP.NET

        group.MapPut("/{id}", (int id, UpdateItemDto updateItem) => {
            var index = items.FindIndex(item => item.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
            items[index] = new ItemDto(
                id,
                updateItem.Name,
                updateItem.Type,
                updateItem.Description,
                updateItem.Price,
                updateItem.ReleaseDate
            );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            items.RemoveAll(item => item.Id == id);
            return Results.NoContent();
        });

        return group;
    }

}
