using System.ComponentModel.DataAnnotations;

namespace PL.src
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? StadiumName { get; set; }
        [Required]
        public int StadiumCapacity { get; set; }
        [Required]
        public int NumberOfPLTitles { get; set; }
        [Required]
        public int NumberOfWins { get; set; }
        [Required]
        public int NumberOfLosses { get; set; }
        [Required]
        public int NumberOfGoalsScored { get; set; }
    }
}
