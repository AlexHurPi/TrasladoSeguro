using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Drivers
{
    public class CreateModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public CreateModel(TransporteSeguroContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}
		[BindProperty]

		public Driver Driver { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Drivers == null || Driver == null)
			{
				return Page();
			}

			_context.Drivers.Add(Driver);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
