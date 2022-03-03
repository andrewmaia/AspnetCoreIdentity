using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreIdentity.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Credential.Username=="admin" || Credential.Username=="presidente")
            {
                //Claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "admin"));
                claims.Add(new Claim(ClaimTypes.Email, "admin@admin.com.br"));
                if (Credential.Username == "presidente")
                {
                    claims.Add(new Claim("Cargo", "Presidente"));
                    claims.Add(new Claim("DataCadastro", "2021-01-01"));
                }
                else
                {
                    claims.Add(new Claim("DataCadastro", "2022-03-01"));
                }

                //Identity
                var identity = new ClaimsIdentity(claims, "CookieAuth");

                //Principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //Configuração se o cookie de autenticação é persistente ou não
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe
                };

                //Adicionando o Principal ao contexto de segurança
                await HttpContext.SignInAsync("CookieAuth", principal, authProperties);

                return RedirectToPage("/Index");

            }

            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
