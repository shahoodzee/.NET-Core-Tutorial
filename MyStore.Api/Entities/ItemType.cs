using MongoDB.Bson;

namespace MyStore.Api.Entities;

public class ItemType
{
    public int Id { get; set; }
    // public ObjectId Id { get; set; }

    public required string Name { get; set; }
}
