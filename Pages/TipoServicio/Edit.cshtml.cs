using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.TipoServicio
{
    public class EditModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public EditModel(TransporteSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]

		public ServiceType ServiceType { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.ServiceTypes == null)
			{
				return NotFound();
			}

			var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(m => m.Id == id);

			if (serviceType == null)
			{
				return NotFound();
			}
			ServiceType = serviceType;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(ServiceType).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ServiceTypeExists(ServiceType.Id))
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

		private bool ServiceTypeExists(int id)
		{
			return (_context.ServiceTypes?.Any(e => e.Id == id)).GetValueOrDefault();
		}

	}
}
