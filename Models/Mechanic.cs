namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Mechanic : Employee
    {
        public ICollection<MechanicRoles>? MechanicRoles;
    }
}