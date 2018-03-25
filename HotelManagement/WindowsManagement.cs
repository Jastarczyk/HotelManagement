using HotelManagement.UserAccessUI;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement
{
    class WindowsManagement
    {
        private static MainWindow mainWindow;
        public static LoginWindow loginWindow;
        public static RegistrationWindow registrationWindow;

        public WindowsManagement(Window startingWindow)
        {
            try
            {
                registrationWindow = new RegistrationWindow();
                loginWindow = (LoginWindow)startingWindow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CreateMainWindow(User loggedUser)
        {
            mainWindow = new MainWindow(loggedUser);
        }

        public static void ShowMainWindow()
        {
            if (mainWindow != null && mainWindow.IsActive != true)
            {
                mainWindow.Show();
            }
        }

        public static MainWindow GetMainWindowInstance()
        {
            return mainWindow;
        }
    }
}
