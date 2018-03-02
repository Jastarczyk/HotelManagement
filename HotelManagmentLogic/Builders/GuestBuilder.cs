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
        private GuestModel guest;

        public GuestBuilder()
        {
            guest = new GuestModel();
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

        public GuestBuilder SetTelephoneNumber(long number)
        {
            guest.TelephoneNumber = number;
            return this;
        }

        public GuestModel Build()
        {
            guest.ID = Guid.NewGuid();
            return guest;
        }
    }
}
