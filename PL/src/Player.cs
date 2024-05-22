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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Nationality { get; set; }
        public string? Team { get; set; }
        public int Apperiances { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int JerseyNumber { get; set; }
    }
}
