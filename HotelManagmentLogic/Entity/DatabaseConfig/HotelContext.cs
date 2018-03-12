namespace HotelManagmentLogic.Entity.DatabaseConfig
{
    using HotelManagmentLogic.Models;
    using HotelManagmentLogic.Models.Acommodation;
    using HotelManagmentLogic.Models.Administration;
    using System.Data.Entity;

    public class HotelContext : DbContext
    {
        public HotelContext(): base("HotelContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelContext, Migrations.Configuration>("HotelContext"));
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
    }
}