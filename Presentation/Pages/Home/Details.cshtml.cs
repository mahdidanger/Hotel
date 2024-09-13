using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotel.Pages.Home
{
    public class DetailsModel : PageModel
    {
        private readonly MyHotelContext _context;

        public DetailsModel(MyHotelContext context)
        {
            _context = context;
        }

        public Hotels Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Hotel = await _context.Hotels.FindAsync(id);

            if (Hotel == null)
            {
                return NotFound();
            }

            return Page();
        }
    }

}
