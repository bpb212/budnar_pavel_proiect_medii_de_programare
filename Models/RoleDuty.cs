namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class RoleDuty
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public Role? Role { get; set; }
        public int DutyID { get; set; }
        public Duty? Duty { get; set; }
    }
}
