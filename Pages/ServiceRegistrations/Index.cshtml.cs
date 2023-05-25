using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ServiceRegistrations
{
	[Authorize]
    public class IndexModel : PageModel
    {
		private readonly TransporteSeguroContext _context;

		public IndexModel(TransporteSeguroContext context)
		{
			_context = context;
		}

		public IList<ServiceRegistration?> ServiceRegistrations { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.ServiceRegistrations != null)
			{
				ServiceRegistrations = await _context.ServiceRegistrations.ToListAsync();
			}

		}
	}
}
