namespace MyStore.Api.Endpoints;

using MyStore.Api.Data;
using MyStore.Api.Dtos;
using MyStore.Api.Entities;
using MyStore.Api.Mapping;

public static class ItemsEndpoints
{
    const string GetItemEndpointName = "GetItem";
    private static readonly List<ItemSummaryDto> items = new List<ItemSummaryDto>
    {
        new (
            Id: 1,
            Name: "The Legend of Zelda: Breath of the Wild",
            Type: "Game",
            Description: "An open-world adventure game set in the Zelda universe.",
            Price: 59.99m,
            ReleaseDate: new DateOnly(2017, 3, 3)
        ),
        new (
            Id: 2,
            Name: "Super Mario Odyssey",
            Type: "Game",
            Description: "A 3D platformer featuring Mario on a globe-trotting adventure.",
            Price: 49.99m,
            ReleaseDate: new DateOnly(2017, 10, 27)
        ),
        new (
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

        group.MapGet("/{id}", (int id, MyStoreContext dbContext) => {
            //ItemDto? item = items.Find(item => item.Id == id); b4 using Dbcontext
            Item? item = dbContext.Items.Find(id);
            ItemDetailsDto itemDetailsDto = item.ToItemDetailsDto(); 
            return item is null ? Results.NotFound() : Results.Ok(itemDetailsDto);

        }).WithName(GetItemEndpointName);

        group.MapPost("/", (CreateItemDto newItem, MyStoreContext dbContext) => {
            // ItemDto item = new (
            //     items.Count+1,
            //     newItem.Name,
            //     newItem.Type,
            //     newItem.Description,
            //     newItem.Price,
            //     newItem.ReleaseDate
            // );
            // items.Add(item);
            // return Results.CreatedAtRoute(GetItemEndpointName, new { id = item.Id }, item);

            //since we now use dbContext service
            
            /* if u dont use mapping            
            Item item = new()
            {
                Name = newItem.Name,
                ItemType = dbContext.ItemTypes.Find(newItem.ItemTypeId),
                ItemTypeId = newItem.ItemTypeId,
                Description = newItem.Description,
                Price = newItem.Price,
                ReleaseDate = newItem.ReleaseDate,
            };
            */
            Item item = newItem.ToEntity();
            // item.ItemType = dbContext.ItemTypes.Find(newItem.ItemTypeId); we dont need this line either
            // EF will take care since we are using two Dtos now Summary and Details.

            dbContext.Items.Add(item);
            dbContext.SaveChangesAsync();


            /*if u dont use mapping*/
            // ItemDto itemDto = new(
            //     item.Id,
            //     item.Name,
            //     item.ItemType!.Name,    // ! tells Name will never gonna be null
            //     item.Description,
            //     item.Price,
            //     item.ReleaseDate
            // );
            ItemDetailsDto itemDetailsDto = item.ToItemDetailsDto();

            return Results.CreatedAtRoute( GetItemEndpointName, new { id = item.Id }, itemDetailsDto);

        }).WithParameterValidation();
        //this function from the MinimalApi.Extensions package works the same as (ModelState.Isvalid ?) in ASP.NET

        group.MapPut("/{id}", (int id, UpdateItemDto updateItem) => {
            var index = items.FindIndex(item => item.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
            items[index] = new ItemSummaryDto(
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
