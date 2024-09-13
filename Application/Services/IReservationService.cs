using Hotel.Domin.Models;

namespace Hotel.Application.Services
{
    public interface IReservationService
    {
        Task<Hotels> GetHotelByIdAsync(int id);
        Task MakeReservationAsync(Reservation reservation);
    }
}
