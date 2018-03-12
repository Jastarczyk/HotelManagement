using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagmentLogic.DatabaseAccess
{
   public static class RoomDbTableOperations
    {
        public static List<Room> GetAllRoomsFromDB()
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Rooms.Select(x => x).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Room>();
            }
        }

        public static List<int> GetAllRoomsNumbersFromDB()
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Rooms.Select(x => x.RoomNumber).ToList();
                }
            }
            catch(Exception)
            {
                return new List<int>();
            }
        }
    }
}
