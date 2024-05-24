using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PL.src
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        [Required]
        public string? Team { get; set; }
        [Required]
        public int Apperiances { get; set; }
        [Required]
        public int Goals { get; set; }
        [Required]
        public int Assists { get; set; }
        [Required]
        public int JerseyNumber { get; set; }
    }
}
