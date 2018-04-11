using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagmentLogic.Models.Administration;

namespace HotelManagmentLogic.Security
{
    public class Administrator : IPermission
    {
        private static Permission permission;

        public Administrator()
        {
            permission = SetDefaultPermission();
        }

        public void ChangePermissionSet(Permission newPermissions)
        {
            permission = newPermissions;
        }

        public Permission GetDefaultPermissions()
        {
            return permission;
        }

        private Permission SetDefaultPermission()
        {
            if (permission == null)
            {
                return new Permission()
                {
                    BookedGuestListPreview = true,
                    CanBookGuest = true,
                    CanAddUser = true,
                    HasAccessToAdminPanel = true,
                    CanEditPermissionInAdminPanel = true,
                };
            }
            return permission;
        }
    }
}
