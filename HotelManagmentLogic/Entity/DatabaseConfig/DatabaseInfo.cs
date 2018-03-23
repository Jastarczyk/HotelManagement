using HotelManagmentLogic.Configuration;
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
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Database.Exists();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetDataBaseName()
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Database.Connection.Database;
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLogger.AddLog(new Logger.ErrorLogger.Error(ex));
                return OutputMessages.DataBaseConnectionError;
            }
        }
    }
}
