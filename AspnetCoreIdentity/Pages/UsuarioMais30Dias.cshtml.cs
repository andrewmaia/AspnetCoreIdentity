using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreIdentity.Pages
{
    
    [Authorize(Policy = "TemQueSerUsuarioMaisUmMes")]
    public class UsuarioMais30DiasModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
