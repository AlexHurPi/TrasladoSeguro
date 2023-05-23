using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientes
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

		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
			{
				return Page();
			}

			_context.Clientes.Add(Cliente);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
