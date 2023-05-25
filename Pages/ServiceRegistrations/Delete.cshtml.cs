using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ServiceRegistrations
{
    public class DeleteModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public DeleteModel(TransporteSeguroContext context)
        {
            _context = context;
        }
        [BindProperty]

        public ServiceRegistration ServiceRegistration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceRegistrations == null)
            {
                return NotFound();
            }

            var serviceregistration = await _context.ServiceRegistrations.FirstOrDefaultAsync(m => m.Id == id);

            if (serviceregistration == null)
            {
                return NotFound();
            }
            else
            {
                ServiceRegistration = serviceregistration;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ServiceRegistrations == null)
            {
                return NotFound();
            }
            var serviceregistrations = await _context.ServiceRegistrations.FindAsync(id);

            if (serviceregistrations != null)
            {
                ServiceRegistration = serviceregistrations;
                _context.ServiceRegistrations.Remove(ServiceRegistration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}