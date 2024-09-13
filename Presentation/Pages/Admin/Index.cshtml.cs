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
    public class IndexModel : PageModel
    {
        private readonly MyHotelContext _context;

        public IndexModel(MyHotelContext context)
        {
            _context = context;
        }

        public IList<Hotels> Hotels { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Hotels = await _context.Hotels.ToListAsync();
        }
    }
}
