using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public DeleteModel(TransporteSeguroContext context)
		{
			_context = context;
		}
		[BindProperty]

		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}

			var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

			if (cliente == null)
			{
				return NotFound();
			}
			else
			{
				Cliente = cliente;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}
			var clientes = await _context.Clientes.FindAsync(id);

			if (clientes != null)
			{
				Cliente = clientes;
				_context.Clientes.Remove(Cliente);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
