using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Administration
{
    public class Permission
    {
        public bool CanBookGuest { get; set; }
        public bool BookedGuestListPreview { get; set; }
        public bool CanAddUser { get; set; }
        public bool HasAccessToAdminPanel { get; set; }
        public bool CanEditPermissionInAdminPanel { get; set; }
    }
}