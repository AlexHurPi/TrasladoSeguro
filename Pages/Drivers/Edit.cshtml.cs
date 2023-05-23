using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Drivers
{
    public class EditModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public EditModel(TransporteSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]

		public Driver Driver { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Drivers == null)
			{
				return NotFound();
			}

			var driver = await _context.Drivers.FirstOrDefaultAsync(m => m.Id == id);

			if (driver == null)
			{
				return NotFound();
			}
			Driver = driver;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Driver).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DriverExists(Driver.Id))
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

		private bool DriverExists(int id)
		{
			return (_context.Drivers?.Any(e => e.Id == id)).GetValueOrDefault();
		}

	}
}
