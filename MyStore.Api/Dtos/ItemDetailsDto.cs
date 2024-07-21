namespace MyStore.Api;

public record class ItemDetailsDto
(
    int Id, 
    string Name, 
    int ItemTypeId,
    string Description, 
    decimal Price,
    DateOnly ReleaseDate
);
