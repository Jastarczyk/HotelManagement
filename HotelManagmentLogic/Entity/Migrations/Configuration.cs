namespace HotelManagmentLogic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Entity.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HotelManagmentLogic.Entity.HotelContext";
        }

        protected override void Seed(Entity.HotelContext context)
        {

        }
    }
}
