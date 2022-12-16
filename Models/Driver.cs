using System.ComponentModel.DataAnnotations;

namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Driver : Employee
    {
        [RegularExpression(@"^[A-Z]{3}", ErrorMessage = "The short name must be exactly 3 characters long.")]

        public string ShortName { get; set; }
    }
}
