﻿using System.ComponentModel.DataAnnotations;

namespace SA_Walks.API.Models.DTO
{
    public class UpdateWalkRequestDto
    {
       
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(0, 20)]
        public double LengthInKm { get; set; }
        
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }

    }
}
