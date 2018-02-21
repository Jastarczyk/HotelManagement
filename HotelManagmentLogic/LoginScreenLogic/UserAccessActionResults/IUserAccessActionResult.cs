using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults
{
    public interface IUserAccessActionResult
    {
        bool UserAccessActionStatus { get; set; }
        string UserAccessActionMessage { get; set; }
    }
}
