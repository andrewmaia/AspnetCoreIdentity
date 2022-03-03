using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCoreIdentity.Pages
{
    [Authorize(Policy = "TemQueSerPresidente")]
    public class PaginaPresidenteModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
