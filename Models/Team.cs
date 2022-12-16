using System.ComponentModel.DataAnnotations;

namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Team
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z]+", ErrorMessage = "The team name must contains only letters and start with an uppercase letter.")]
        public string Name { get; set; }
        public ICollection<Driver>? Drivers { get; set; }
        public ICollection<Mechanic>? Mechanics { get; set; }
    }
}
