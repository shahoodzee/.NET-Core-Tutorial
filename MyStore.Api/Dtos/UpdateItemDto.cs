﻿using System.ComponentModel.DataAnnotations;
namespace MyStore.Api.Dtos;

public record class UpdateItemDto
(
    [Required][StringLength(50)] string Name,
    [StringLength(100)] string Type,
    [StringLength(100)] string Description,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
