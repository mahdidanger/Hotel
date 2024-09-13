using Hotel.Application.Services;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly MyHotelContext _context;

        public ReservationService(MyHotelContext context)
        {
            _context = context;
        }
        public async Task<Hotels> GetHotelByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);
        }

        public async Task MakeReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
