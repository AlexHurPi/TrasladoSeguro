using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Register
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
        [TempData]//para poner mensaje registro satisfactorio
        public string ErrorMessage { get; set; }//para poner mensaje registro satisfactorio
        [BindProperty]

		public User User { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Users == null || User == null)
			{
				return Page();
			}

			_context.Users.Add(User);
			await _context.SaveChangesAsync();
            ErrorMessage = "User created succesfully";//para poner mensaje de error 
            return RedirectToPage("/Account/Login");
		}
	}
}
