using budnar_pavel_proiect_medii_de_programare.Data;
using budnar_pavel_proiect_medii_de_programare.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace budnar_pavel_proiect_medii_de_programare.Pages.Model
{
    public class RolePageModel : PageModel
    {
        public List<AssignedDuties> AssignedDuties;

        public void PopulateAssignedDuties(budnar_pavel_proiect_medii_de_programareContext context, Role role)
        {
            var allDuties = context.Duty;
            var duties = new HashSet<int>(role.RoleDuty.Select(d => d.DutyID));
            AssignedDuties = new List<AssignedDuties>();
            foreach (var duty in allDuties)
            {
                AssignedDuties.Add(new AssignedDuties
                {
                    DutyID = duty.ID,
                    Name = duty.DutyName,
                    Assigned = duties.Contains(duty.ID)
                });
            }
        }

        public void UpdateRoleDuties(budnar_pavel_proiect_medii_de_programareContext context, string[] selectedDuties, Role role)
        {
            if (selectedDuties == null)
            {
                role.RoleDuty = new List<RoleDuty>();
                return;
            }

            var selectedDutiesHS = new HashSet<string>(selectedDuties);
            var duties = new HashSet<int>(role.RoleDuty.Select(d => d.DutyID));
            foreach (var duty in context.Duty)
            {
                if (selectedDutiesHS.Contains(duty.ID.ToString()))
                {
                    if (!duties.Contains(duty.ID))
                    {
                        role.RoleDuty.Add(new RoleDuty
                        {
                            RoleID = role.ID,
                            DutyID = duty.ID
                        });
                    }
                }
                else
                {
                    if (duties.Contains(duty.ID))
                    {
                        RoleDuty courseToRemove = role.RoleDuty.SingleOrDefault(i => i.DutyID == duty.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
