using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Drivers
{
    [Authorize]
    public class IndexModel : PageModel
    {        
            private readonly TransporteSeguroContext _context;

            public IndexModel(TransporteSeguroContext context)
            {
                _context = context;
            }

            public IList<Driver> Driver { get; set; } = default!;

            public async Task OnGetAsync()
            {
                if (_context.Drivers != null)
                {
                    Driver = await _context.Drivers.ToListAsync();
                }
            }
    }
}

