using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Drivers
{
    public class DeleteModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public DeleteModel(TransporteSeguroContext context)
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
			else
			{
				Driver = driver;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Drivers == null)
			{
				return NotFound();
			}
			var drivers = await _context.Drivers.FindAsync(id);

			if (drivers != null)
			{
				Driver = drivers;
				_context.Drivers.Remove(Driver);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
