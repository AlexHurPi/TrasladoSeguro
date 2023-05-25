using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ServiceRegistrations
{
    public class EditModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public EditModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Cliente { get; set; }
        public List<SelectListItem> Driver { get; set; }
        public List<SelectListItem> ServiceType { get; set; }

        [BindProperty]
        public ServiceRegistration ServiceRegistration { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ServiceRegistration = await _context.ServiceRegistrations.FindAsync(id);

            if (ServiceRegistration == null)
            {
                return NotFound();
            }

            await PopulateDropdownLists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownLists();
                return Page();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Identification == ServiceRegistration.ClienteIdentification);
            var driver = await _context.Drivers.FirstOrDefaultAsync(p => p.Identification == ServiceRegistration.DriverIdentification);
            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(st => st.Name == ServiceRegistration.ServiceType);

            if (cliente == null || driver == null || serviceType == null)
            {
                ModelState.AddModelError("", "Invalid Customer, Driver, or Service Type selected.");
                await PopulateDropdownLists();
                return Page();
            }

            ServiceRegistration.ClienteName = cliente.Name;
            ServiceRegistration.DriverName = driver.Name;

            _context.Attach(ServiceRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRegistrationExists(ServiceRegistration.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task PopulateDropdownLists()
        {
            Cliente = await _context.Clientes
                .Where(c => !string.IsNullOrEmpty(c.Name))
                .Select(c => new SelectListItem
                {
                    Value = c.Identification,
                    Text = c.Name
                })
                .ToListAsync();

            Driver = await _context.Drivers
                .Where(d => !string.IsNullOrEmpty(d.Name))
                .Select(d => new SelectListItem
                {
                    Value = d.Identification,
                    Text = d.Name
                })
                .ToListAsync();

            ServiceType = await _context.ServiceTypes
                .Where(st => !string.IsNullOrEmpty(st.Name))
                .Select(st => new SelectListItem
                {
                    Value = st.Name,
                    Text = st.Name
                })
                .ToListAsync();
        }

        private bool ServiceRegistrationExists(int id)
        {
            return _context.ServiceRegistrations.Any(e => e.Id == id);
        }
    }
}

