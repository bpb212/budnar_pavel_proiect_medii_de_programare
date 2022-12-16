using budnar_pavel_proiect_medii_de_programare.Models;
using System.Security.Policy;

namespace budnar_pavel_proiect_medii_de_programare.Pages.ViewModels
{
    public class TeamIndexData
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Mechanic> Mechanics { get; set; }
    }
}
