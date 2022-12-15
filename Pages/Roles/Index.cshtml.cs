using Microsoft.EntityFrameworkCore;
using budnar_pavel_proiect_medii_de_programare.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext _context;

        public IndexModel(budnar_pavel_proiect_medii_de_programare.Data.budnar_pavel_proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IList<Role> Role { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Role != null)
            {
                Role = await _context.Role.Include(r => r.RoleDuty).ThenInclude(d => d.Duty).ToListAsync();
            }
        }
    }
}
