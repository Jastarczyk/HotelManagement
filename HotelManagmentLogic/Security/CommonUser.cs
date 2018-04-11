using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Security
{
    public class CommonUser : IPermission
    {
        private static Permission permissions;

        public CommonUser()
        {
            permissions = SetDefaultPermission();
        }

        public Permission GetDefaultPermissions()
        {
            return permissions;
        }

        public void ChangePermissionSet(Permission newPermissions)
        {
            permissions = newPermissions;
        }

        private Permission SetDefaultPermission()
        {
            if (permissions == null)
            {
                return new Permission()
                {
                    BookedGuestListPreview = true,
                    CanBookGuest = true,
                    CanAddUser = false,
                    HasAccessToAdminPanel = false,
                    CanEditPermissionInAdminPanel = false,
                };
            }
            return permissions;
        }
    }
}
