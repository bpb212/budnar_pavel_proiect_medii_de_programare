namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class MechanicRoles
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int MechanincID { get; set; }
        public Mechanic Mechanic { get; set; }
    }
}
