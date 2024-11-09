using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Cores.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Countires> Countires { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<FeedBacks> FeedBacks { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<RoomStatuses> RoomStatuses { get; set; }
        public DbSet<RoomTypes> RoomTypes { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ReservationStatuses> ReservationStatuses { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoomAmenities>(e =>
             e.HasKey(u => new { u.AmenityId, u.RoomTypeId })
            );
        }
    }
}
