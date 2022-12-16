using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Mechanics
{
    public class IndexModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public IndexModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IList<Mechanic> Mechanic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mechanic != null)
            {
                Mechanic = await _context.Mechanic
                    .Include(mechanic => mechanic.Role)
                    .Include(mechanic => mechanic.Team)
                    .ToListAsync();
            }
        }
    }
}
