// namespace MyStore.Api.Endpoints;
// // using GameStore.Api.Mapping;
// using Microsoft.EntityFrameworkCore;
// using MyStore.Api.Data;
// using MyStore.Api.Entities;
// using MongoDB.Bson;

// public static class ItemTypesEndpoints
// {
//     public static RouteGroupBuilder MapItemTypesEndpoints(this WebApplication app){

//         var group = app.MapGroup("itemtypes");

//         /*
//             When using  MongoDB
//             group.MapPost("/", async (MyStoreContext context, ItemType itemType) =>{
//                 await context.ItemTypes.AddAsync(itemType);
//                 await context.SaveChangesAsync();
//             });


//             group.MapGet("/{id}", async (MyStoreContext context, string id) => {
//                 var objectId = new ObjectId(id);
//                 var itemType = await context.ItemTypes.FindAsync(objectId);
//                 if (itemType == null)
//                 {
//                     return Results.NotFound();
//                 }
//                 var result = new { 
//                     Id = itemType.Id.ToString(), 
//                     itemType.Name
//                 };
//                 return Results.Ok(result);
//             });

//         */

//         group.MapGet("/", async (MyStoreContext dbContext) =>
//             await dbContext.Genres
//                            .Select(genre => genre.ToDto())
//                            .AsNoTracking()
//                            .ToListAsync());
                           
//         return group;

//     }
// }