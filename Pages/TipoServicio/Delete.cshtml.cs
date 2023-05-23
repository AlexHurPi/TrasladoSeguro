using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.TipoServicio
{
    public class DeleteModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public DeleteModel(TransporteSeguroContext context)
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
			else
			{
				ServiceType = serviceType;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.ServiceTypes == null)
			{
				return NotFound();
			}
			var serviceTypes = await _context.ServiceTypes.FindAsync(id);

			if (serviceTypes != null)
			{
				ServiceType = serviceTypes;
				_context.ServiceTypes.Remove(ServiceType);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
