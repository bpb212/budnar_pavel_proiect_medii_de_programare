namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<RoleDuty>? RoleDuty { get; set; }
    }
}