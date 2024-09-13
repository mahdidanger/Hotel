using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;

namespace Hotel.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly MyHotelContext _context;

        public DetailsModel(MyHotelContext context)
        {
            _context = context;
        }

        public Hotels Hotels { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels.FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotels == null)
            {
                return NotFound();
            }
            else
            {
                Hotels = hotels;
            }
            return Page();
        }
    }
}
