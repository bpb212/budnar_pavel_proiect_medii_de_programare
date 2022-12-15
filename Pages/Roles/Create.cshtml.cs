using Microsoft.AspNetCore.Mvc;
using budnar_pavel_proiect_medii_de_programare.Models;
using budnar_pavel_proiect_medii_de_programare.Pages.Model;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Roles
{
    public class CreateModel : RolePageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public CreateModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var role = new Role();
            role.RoleDuty = new List<RoleDuty>();
            PopulateAssignedDuties(_context, role);

            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedDuties)
        {
            var newRole = new Role();
            if (selectedDuties != null)
            {
                newRole.RoleDuty = new List<RoleDuty>();
                foreach (var duty in selectedDuties)
                {
                    RoleDuty dutyToAdd = new RoleDuty
                    {
                        DutyID = int.Parse(duty)
                    };
                    newRole.RoleDuty.Add(dutyToAdd);
                }
            }

            if (await TryUpdateModelAsync<Role>(newRole, "Role", i => i.Name ))
            {
                _context.Role.Add(newRole);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedDuties(_context, newRole);
            return Page();
        }
    }
}
