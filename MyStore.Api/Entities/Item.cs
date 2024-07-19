namespace MyStore.Api.Entities;

public class Item
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }    

    public int ItemTypeId { get; set; }

    public ItemType? ItemType { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
