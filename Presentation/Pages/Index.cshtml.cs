using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Pages
{
    public class IndexModel : PageModel
    {
        private MyHotelContext _context;
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger , MyHotelContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public List<Hotels> ListHotels { get; set; }
        public void OnGet()
        {
             ListHotels = _context.Hotels.ToList();
        }
    }
}
