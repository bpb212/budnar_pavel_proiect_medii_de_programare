using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using budnar_pavel_proiect_medii_de_programare.Models;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Drivers
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
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; }
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Driver newDriver = new Driver();

            if (await TryUpdateModelAsync<Driver>(newDriver, "Driver", i => i.FirstName, i => i.LastName, i => i.ShortName, i => i.TeamID))
            {
                _context.Driver.Add(newDriver);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "Name");

            return Page();
        }
    }
}
