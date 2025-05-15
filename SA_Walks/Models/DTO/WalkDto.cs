using System.Drawing;
using SA_Walks.API.Models.Domain;

namespace SA_Walks.API.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        
        public string? WalkImageUrl { get; set; }

              


        // Navigation properties
        public DifficultyDto Difficulty { get; set; }

        public RegionDto Region { get; set; }

    }
}
