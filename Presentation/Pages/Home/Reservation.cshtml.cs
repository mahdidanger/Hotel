using Hotel.Application.Services;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Hotel.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Pages.Home
{
    public class ReservationModel : PageModel
    {
        private IReservationService _reservationService;
        public ReservationModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [BindProperty]
        public Hotels Hotels { get; set; }

        [BindProperty]
        public Reservation Reservation { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Hotels = await _reservationService.GetHotelByIdAsync(id);
            if (Hotels == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Reservation.HotelId = Hotels.HotelId;
            Reservation.ReservationDate = DateTime.Now;
            await _reservationService.MakeReservationAsync(Reservation);
            
            
            return RedirectToPage("Payment", new { reservationId = Reservation.ReservationId });
        }
    }
}
