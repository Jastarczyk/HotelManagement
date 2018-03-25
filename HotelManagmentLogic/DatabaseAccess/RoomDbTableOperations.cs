using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Models;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagmentLogic.DatabaseAccess
{
   public static class RoomDbTableOperations
    {
        //TODO replace those methods with generic type 
        public static List<Guest> GetAllGuestList()
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Guests.Select(x => x).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Guest>();
            }
        }

        public static List<Room> GetAllRoomsList()
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

        public static List<int> GetNumbersFromAvaiableRooms()
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
