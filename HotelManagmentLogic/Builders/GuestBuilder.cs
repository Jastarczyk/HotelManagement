using HotelManagmentLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Builders
{
    public class GuestBuilder
    {
        private Guest guest;

        public GuestBuilder()
        {
            guest = new Guest();
        }

        public GuestBuilder SetName(string name)
        {
            guest.Name = name;
            return this;
        }

        public GuestBuilder SetSurname(string surname)
        {
            guest.Surname = surname;
            return this;
        }

        public GuestBuilder SetAddress(string address)
        {
            guest.Address = address;
            return this;
        }

        public GuestBuilder SetEmail(string email)
        {
            guest.Email = email;
            return this;
        }

        public GuestBuilder SetTelephoneNumber(string number)
        {
            guest.TelephoneNumber = number;
            return this;
        }


        public GuestBuilder SetRoom(int roomID)
        {
            guest.RoomID = roomID;
            return this;
        }

        public GuestBuilder SetBooking(int bookingID)
        {
            guest.BookingID = bookingID;
            return this;
        }

        public Guest Build()
        {
            return guest;
        }

    }

}
