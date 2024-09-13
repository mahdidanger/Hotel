namespace Hotel.Domin.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int HotelId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PersonCount { get; set; }
        public int RoomId { get; set; }
        public decimal Price { get; set; }
    }
}
