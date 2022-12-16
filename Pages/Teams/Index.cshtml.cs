using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;
using budnar_pavel_proiect_medii_de_programare.Pages.ViewModels;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public IndexModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;
        public TeamIndexData TeamData { get; set; }
        public int TeamID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            TeamData = new TeamIndexData();
            TeamData.Teams = await _context.Team.OrderBy(team => team.Name).ToListAsync();
            
            if (id != null)
            {
                TeamID = id.Value;
                TeamData.Mechanics = await _context.Mechanic.Where(m => m.TeamID == TeamID).ToListAsync();
                TeamData.Drivers = await _context.Driver.Where(m => m.TeamID == TeamID).ToListAsync();
            }
        }
    }
}
