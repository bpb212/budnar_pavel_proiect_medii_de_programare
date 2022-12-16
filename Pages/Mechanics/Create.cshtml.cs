using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using budnar_pavel_proiect_medii_de_programare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Mechanics
{
    public class CreateModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public CreateModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RoleID"] = new SelectList(_context.Set<Role>(), "ID", "Name");
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Mechanic Mechanic { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Mechanic newMechanic = new Mechanic();

            if (await TryUpdateModelAsync<Mechanic>(newMechanic, "Mechanic", i => i.FirstName, i => i.LastName, i => i.RoleID, i => i.TeamID))
            {
                _context.Mechanic.Add(newMechanic);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["RoleID"] = new SelectList(_context.Set<Role>(), "ID", "Name");
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");

            return Page();
        }
    }
}
