using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.GuestsControlLogic
{
    public class GuestRegister
    {
        public AddNewGuestResult Add(string name, string surname, string email, string number, string address)
        {
            if (!long.TryParse(number, out long parsedNumber))
            {
                return BuildAddNewGuestResult(null, false, string.Concat(Configuration.OutputMessages.ValidArgumentName, nameof(number)), null);
            }

            GuestModel newGuest = new GuestBuilder().SetName(name)
                                                    .SetSurname(surname)
                                                    .SetEmail(email)
                                                    .SetTelephoneNumber(parsedNumber)
                                                    .SetAddress(address)
                                                    .Build();
            try
            {
                using (var holetContext = new HotelContext())
                {
                    holetContext.Guests.Add(newGuest);
                    holetContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                BuildAddNewGuestResult(newGuest, false, Configuration.OutputMessages.InternalError, ex);
            }

            return BuildAddNewGuestResult(newGuest, false, Configuration.OutputMessages.GuestSuccessfulMessage);
        }

        private AddNewGuestResult BuildAddNewGuestResult(GuestModel guest, bool status, string message, Exception exception = null)
        {
            return new AddNewGuestResult()
            {
                AddingGuest = guest,
                AddOperationSuccess = status,
                Message = message,
                PossibleException = exception,
            };
        }
    }
}
