using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Users
{
    public class DeleteModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public DeleteModel(TransporteSeguroContext context)
		{
			_context = context;
		}
		[BindProperty]

		public User User { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

			if (user == null)
			{
				return NotFound();
			}
			else
			{
				User = user;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}
			var users = await _context.Users.FindAsync(id);

			if (users != null)
			{
				User = users;
				_context.Users.Remove(User);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
