using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults
{
    public class LoginResult : AddToDatabaseResult
    {
        public User AccessingUser { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
