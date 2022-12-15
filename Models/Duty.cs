namespace budnar_pavel_proiect_medii_de_programare.Models
{
    public class Duty
    {
        public int ID { get; set; }
        public string? DutyName { get; set; }
        public ICollection<RoleDuty>? RoleDuties { get; set; }
    }
}