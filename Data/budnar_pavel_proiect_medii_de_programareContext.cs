using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;

namespace budnar_pavel_proiect_medii_de_programare.Data
{
    public class budnar_pavel_proiect_medii_de_programareContext : DbContext
    {
        public budnar_pavel_proiect_medii_de_programareContext (DbContextOptions<budnar_pavel_proiect_medii_de_programareContext> options)
            : base(options)
        {
        }

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.Driver> Driver { get; set; } = default!;

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.Duty> Duty { get; set; }

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.Mechanic> Mechanic { get; set; }

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.Role> Role { get; set; }

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.Team> Team { get; set; }

        public DbSet<budnar_pavel_proiect_medii_de_programare.Models.MechanicRoles> MechanicRoles { get; set; }
    }
}
