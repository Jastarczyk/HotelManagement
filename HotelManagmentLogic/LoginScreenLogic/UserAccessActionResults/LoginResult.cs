using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults
{
    public class LoginResult : IUserAccessActionResult
    {
        public bool UserAccessActionStatus { get; set; }
        public string UserAccessActionMessage { get; set; }
        public UserModel LoggedUser { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
