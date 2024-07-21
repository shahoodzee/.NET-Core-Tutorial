// why we use records in Dtos instead of standard class ?
using System.ComponentModel.DataAnnotations;

namespace MyStore.Api.Dtos;

public record class CreateItemDto(    
    [Required][StringLength(50)] string Name,
    int ItemTypeId,
    [Required][StringLength(100)] string Description, 
    [Range(1,100)]decimal Price, 
    DateOnly ReleaseDate
);
