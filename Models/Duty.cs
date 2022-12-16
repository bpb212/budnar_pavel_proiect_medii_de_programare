using System.ComponentModel.DataAnnotations;

namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Duty
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3, ErrorMessage = "The duty must be longer than 3 characters")]
        public string? DutyName { get; set; }
        public ICollection<RoleDuty>? RoleDuties { get; set; }
    }
}