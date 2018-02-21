using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults
{
    public class RegistrationResult : IUserAccessActionResult
    {
        public bool UserAccessActionStatus { get; set; }
        public string UserAccessActionMessage { get; set; }
    }
}
