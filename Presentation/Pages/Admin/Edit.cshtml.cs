


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;

namespace Hotel.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly MyHotelContext _context;

        public EditModel(MyHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotels Hotels { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels =  await _context.Hotels.FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotels == null)
            {
                return NotFound();
            }
            Hotels = hotels;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hotels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(Hotels.HotelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HotelsExists(int id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }
    }
}
