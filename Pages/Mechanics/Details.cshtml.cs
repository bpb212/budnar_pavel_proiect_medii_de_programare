using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Mechanics
{
    public class DetailsModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public DetailsModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

      public Mechanic Mechanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }

            var mechanic = await _context.Mechanic
                .Include(mechanic => mechanic.Team)
                .Include(mechanic => mechanic.Role)
                    .ThenInclude(role => role.RoleDuty)
                    .ThenInclude(duty => duty.Duty)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mechanic == null)
            {
                return NotFound();
            }
            else 
            {
                Mechanic = mechanic;
            }
            return Page();
        }
    }
}
