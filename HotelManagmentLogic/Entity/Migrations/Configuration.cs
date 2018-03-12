namespace HotelManagmentLogic.Migrations
{
    using HotelManagmentLogic.Entity.DatabaseConfig;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HotelManagmentLogic.Entity.HotelContext";
        }

        protected override void Seed(HotelContext context)
        {
        }
    }
}
