using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domin.Models
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }
        public int? HotelId { get; set; }
        public Hotels Hotel { get; set; }
        public bool IsModir { get; set; }
    }
}
