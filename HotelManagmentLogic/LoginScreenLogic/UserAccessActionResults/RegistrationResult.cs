using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults
{
    public class RegistrationResult : AddToDatabaseResult
    {
        public User RegisteringUser { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
