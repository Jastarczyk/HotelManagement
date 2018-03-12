using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Entity.DatabaseConfig
{
    public class DatabaseInfo
    {
        public static bool CheckDataBaseConnection()
        {
            using (HotelContext hotelContext = new HotelContext())
            {
                return hotelContext.Database.Exists();
            }
        }

        public static string GetDataBaseName()
        {
            using (HotelContext hotelContext = new HotelContext())
            {
                return hotelContext.Database.Connection.Database;
            }
        }
    }
}
