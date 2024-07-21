using MongoDB.Bson;
namespace MyStore.Api.Entities;

public class Item
{
    public int Id { get; set; }
    // public ObjectId Id { get; set; } //MongoDb uses ObjectId as the deafult value of each id present in MongoDB collection

    public required string Name { get; set; }

    public int ItemTypeId { get; set; }

    public ItemType? ItemType { get; set; }
    public required string Description { get; set; }    


    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
