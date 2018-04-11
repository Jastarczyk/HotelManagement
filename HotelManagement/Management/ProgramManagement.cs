using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.Management
{
    internal class ProgramManagement
    {
        private static User currentUser;

        internal static void Initialize(Window startingWindow)
        {
            //set starting windows
            new WindowsManagement(startingWindow);

            //check database connection
            if (!DatabaseInfo.CheckDataBaseConnection())
            {
                MessageBox.Show(HotelManagmentLogic.Configuration.OutputMessages.DataBaseConnectionError);
                Application.Current.Shutdown();
            }
        }

        internal static void SetLoggedUser(User user)
        {
            currentUser = user;
        }

        public static User GetLoggedUser()
        {
            return currentUser?? new User();
        }
    }
}
