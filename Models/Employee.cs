using System.ComponentModel.DataAnnotations;

namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+", ErrorMessage = "The first name must contains only letters and start with an uppercase letter.")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+", ErrorMessage = "The Last name must contains only letters and start with an uppercase letter.")]
        public string LastName { get; set; }
        public int TeamID { get; set; }
        public Team? Team { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
