using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagmentLogic.Models.Administration;

namespace HotelManagmentLogic.Security
{
    public class Manager : IPermission
    {
        private Permission permissions;

        public Manager()
        {
            permissions = SetDefaultPermission();
        }

        public void ChangePermissionSet(Permission newPermissions)
        {
            permissions = newPermissions;
        }

        public Permission GetDefaultPermissions()
        {
            return permissions;
        }

        private Permission SetDefaultPermission()
        {
            if (permissions == null)
            {
                return new Permission()
                {
                    BookedGuestListPreview = true,
                    CanBookGuest = true,
                    CanAddUser = true,
                    HasAccessToAdminPanel = false,
                    CanEditPermissionInAdminPanel = false,
                };
            }
            return permissions;
        }
    }
}
