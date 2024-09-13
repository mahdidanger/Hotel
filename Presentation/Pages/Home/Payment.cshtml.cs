using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hotel.Pages.Home
{
    public class PaymentModel : PageModel
    {
        private readonly MyHotelContext _context;

        public PaymentModel(MyHotelContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Reservation Reservation { get; set; }
        [BindProperty]
        public Hotels Hotels { get; set; }

        public async Task<IActionResult> OnGetAsync(int reservationId)
        {
            Reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == reservationId);
            Hotels = await _context.Hotels.FirstOrDefaultAsync();

            if (Reservation == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int reservationId, string paymentMethod)
        {
            return Page();
        }
    }
}
