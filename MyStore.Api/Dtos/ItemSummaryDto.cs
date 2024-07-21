// why we use records in Dtos instead of standard class ?
namespace MyStore.Api.Dtos;

public record class ItemSummaryDto(    
    int Id, 
    string Name,
    string Type,
    string Description, 
    decimal Price,
    DateOnly ReleaseDate
);
