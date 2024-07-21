using MyStore.Api.Dtos;
using MyStore.Api.Entities;

namespace MyStore.Api.Mapping;

public static class GameMapping
{
    public static Item ToEntity(this CreateItemDto item)
    {
        return new Item()
        {
            Name = item.Name,
            ItemTypeId = item.ItemTypeId,
            Description = item.Description,            
            Price = item.Price,
            ReleaseDate = item.ReleaseDate
        };
    }

    public static ItemSummaryDto ToItemSummaryDto(this Item item)
    {
        return new
        (
            item.Id,
            item.Name,
            item.ItemType!.Name,    // ! tells Name will never gonna be null
            item.Description,
            item.Price,
            item.ReleaseDate
        );
    }
    
    public static ItemDetailsDto ToItemDetailsDto(this Item item)
    {
        return new(
            item.Id,
            item.Name,
            item.ItemTypeId,
            item.Description,
            item.Price,
            item.ReleaseDate
        );
    }    
}
