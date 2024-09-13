using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;

namespace Hotel.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly MyHotelContext _context;

        public CreateModel(MyHotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hotels Hotels { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hotels.Add(Hotels);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
