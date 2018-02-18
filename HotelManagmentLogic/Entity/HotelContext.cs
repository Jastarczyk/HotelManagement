namespace HotelManagmentLogic.Entity
{
    using HotelManagmentLogic.Models.Administration;
    using System.Data.Entity;

    public class HotelContext : DbContext
    {
        public HotelContext(): base("HotelContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelContext, Migrations.Configuration>("HotelContext"));
        }

        public virtual DbSet<UserModel> Users { get; set; }

    }
}