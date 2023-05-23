using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Users
{
    public class IndexModel : PageModel
    {        
            private readonly TransporteSeguroContext _context;

            public IndexModel(TransporteSeguroContext context)
            {
                _context = context;
            }

            public IList<User> User { get; set; } = default!;

            public async Task OnGetAsync()
            {
                if (_context.Users != null)
                {
				User = await _context.Users.ToListAsync();
                }
            }
    }
}

