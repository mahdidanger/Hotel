using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages.Home
{
    [Authorize]
    public class ContactUsModel : PageModel
    {
        
        public void OnGet()
        {
            
        }
    }
}
