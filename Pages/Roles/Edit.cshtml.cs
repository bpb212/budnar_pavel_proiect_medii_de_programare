using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;
using budnar_pavel_proiect_medii_de_programare.Pages.Model;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Roles
{
    public class EditModel : RolePageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public EditModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            Role = await _context.Role.Include(r => r.RoleDuty).ThenInclude(ro => ro.Duty).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            if (Role == null)
            {
                return NotFound();
            }

            PopulateAssignedDuties(_context, Role);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDuties)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var roleToUpdate = await _context.Role
                .Include(r => r.RoleDuty)
                    .ThenInclude(role => role.Duty)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (roleToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Role>(roleToUpdate, "Role", i => i.Name))
            {
                UpdateRoleDuties(_context, selectedDuties, roleToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedDuties(_context, Role);
            return Page();
        }

        private bool RoleExists(int id)
        {
          return _context.Role.Any(e => e.ID == id);
        }
    }
}
