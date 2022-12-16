namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Mechanic : Employee
    {
        public int RoleID { get; set; }
        public Role? Role { get; set; }
    }
}