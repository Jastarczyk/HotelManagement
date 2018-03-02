namespace HotelManagmentLogic.Entity
{
    using HotelManagmentLogic.Models;
    using HotelManagmentLogic.Models.Administration;
    using System.Data.Entity;

    public class HotelContext : DbContext
    {
        public HotelContext(): base("HotelContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelContext, Migrations.Configuration>("HotelContext"));
        }
        //TODO: add for register guests and other models
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<GuestModel> Guests { get; set; }
    }
}