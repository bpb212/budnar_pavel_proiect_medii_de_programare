using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Drivers
{
    public class EditModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public EditModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Driver Driver { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver =  await _context.Driver.Include(drv => drv.Team).FirstOrDefaultAsync(m => m.ID == id);
            if (driver == null)
            {
                return NotFound();
            }
            Driver = driver;
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

            Driver driver = await _context.Driver
                .Include(m => m.Team)
                .FirstOrDefaultAsync(Driver => Driver.ID == id);

            if (driver == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Driver>(driver, "Driver", i => i.FirstName, i => i.LastName, i => i.ShortName, i => i.TeamID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");

            return Page();
        }
    }
}
