using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public LoginModel(TransporteSeguroContext context)
        {
            _context = context;
        }
        [TempData]//para pober mensaje de error
        public string ErrorMessage { get; set; }//para poner mensaje de error
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            foreach (var user in _context.Users)
            {
                var email = user.Email;
                var password = user.Password;
                if (User.Email == email && User.Password == password || User.Email=="admin@gmail.com" && User.Password=="12345")
                {
                    //se crea los claim, datos a almacenar en la cookie
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                    //se asocia los claims creados a un nombre de una cookie
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    //Se agrega la identidad creada al ClaimPrincipal de la aplicacion
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    // se registra exitosamente la autenticacion y se crea la cookie en el navegador
                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                    return RedirectToPage("/index");
                }
            }
            ErrorMessage = "Correo o contraseña incorrectos.";//para poner mensaje de error 
            return Page();
        }
    }
}

