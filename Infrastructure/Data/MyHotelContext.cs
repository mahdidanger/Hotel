using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Hotel.Domin.Models;

namespace Hotel.Infrastructure.Data
{
    public class MyHotelContext : IdentityDbContext<IdentityUser>
    {
        public MyHotelContext(DbContextOptions<MyHotelContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Hotels> Hotels { get; set; }

        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            base.OnModelCreating(builder);



        }

    }

}
