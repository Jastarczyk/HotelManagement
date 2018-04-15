using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Security
{
    public interface IPermission
    {
        void ChangePermissionSet(Permission newPermissions);
        Permission GetDefaultPermissions();
    }
}
