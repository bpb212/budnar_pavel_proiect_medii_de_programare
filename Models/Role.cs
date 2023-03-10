using System.ComponentModel.DataAnnotations;

namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3, ErrorMessage = "The role name must be longer than 3 characters")]
        public string Name { get; set; }
        public ICollection<RoleDuty>? RoleDuty { get; set; }
    }
}