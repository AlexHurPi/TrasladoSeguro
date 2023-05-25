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
	public class CreateModel : PageModel
	{
		private readonly TransporteSeguroContext _context;

		public CreateModel(TransporteSeguroContext context)
		{
			_context = context;
		}

		public List<SelectListItem> Cliente { get; set; }
		public List<SelectListItem> Driver { get; set; }
		public List<SelectListItem> ServiceType { get; set; }

		[BindProperty]
		public ServiceRegistration ServiceRegistration { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			await PopulateDropdownLists();
			ServiceRegistration = new ServiceRegistration
			{
				Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")
			};

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
			var servicetype = await _context.ServiceTypes.FirstOrDefaultAsync(pm => pm.Name == ServiceRegistration.ServiceType);

			if (cliente == null || driver == null || servicetype == null)
			{
				ModelState.AddModelError("", "Invalid Customer, Driver, or Service Type selected.");
				await PopulateDropdownLists();
				return Page();
			}

			ServiceRegistration.ClienteName = cliente.Name;
			ServiceRegistration.DriverName = driver.Name;

			_context.ServiceRegistrations.Add(ServiceRegistration);
			await _context.SaveChangesAsync();

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
	}
}

