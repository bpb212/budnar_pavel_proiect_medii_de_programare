namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Driver>? Drivers { get; set; }
        public ICollection<Mechanic>? Mechanics { get; set; }
    }
}
