using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SA_Walks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Code must be minimum 1 character")]
        [MaxLength(3, ErrorMessage = "Code must be maximum 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name must be maximum 50 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
