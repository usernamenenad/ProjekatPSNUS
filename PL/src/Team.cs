using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.src
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StadiumName { get; set; }
        public int StadiumCapacity { get; set; }
    }
}
