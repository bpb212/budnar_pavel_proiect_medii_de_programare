using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Mechanics
{
    public class EditModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public EditModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mechanic Mechanic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }

            var mechanic =  await _context.Mechanic.Include(mechanic => mechanic.Role).FirstOrDefaultAsync(m => m.ID == id);
            if (mechanic == null)
            {
                return NotFound();
            }
            Mechanic = mechanic;
            ViewData["RoleID"] = new SelectList(_context.Set<Role>(), "ID", "Name");
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mechanic mechanic = await _context.Mechanic
                .Include(m => m.Role)
                .Include(m => m.Team)
                .FirstOrDefaultAsync(Role=> Role.ID == id);
            
            if(mechanic == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Mechanic>(mechanic, "Mechanic", i => i.FirstName, i => i.LastName, i => i.Role, i => i.TeamID))
            { 
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["RoleID"] = new SelectList(_context.Set<Role>(), "ID", "Name");
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");

            return Page();
        }
    }
}
