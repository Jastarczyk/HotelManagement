using HotelManagement.InnerContent;
using HotelManagement.UserAccessUI;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Management
{
    class WindowsManagement
    {
        private static MainWindow mainWindow;
        public static LoginWindow loginWindow;
        public static RegistrationWindow registrationWindow;

        #region InnerContent

        private static AdministrationControl administrationControl;
        private static DashboardControl dashboardControl;
        private static GuestsControl guestsControl;
        private static RoomsControl roomsControl;

        public static AdministrationControl GetAdministrationControlInstance()
        {
            if (administrationControl == null)
            {
                administrationControl = new AdministrationControl();
            }
            return administrationControl;
        }

        public static DashboardControl GetDashboardControlInstance()
        {
            if (dashboardControl == null)
            {
                dashboardControl = new DashboardControl();
            }
            return dashboardControl;
        }

        public static GuestsControl GetGuestsControlInstance()
        {
            if (guestsControl == null)
            {
                guestsControl = new GuestsControl();
            }
            return guestsControl;
        }

        public static RoomsControl GetRoomsControlInstance()
        {
            if (roomsControl == null)
            {
                roomsControl = new RoomsControl();
            }
            return roomsControl;
        }

        #endregion

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

        public static void CreateMainWindow()
        {
            mainWindow = new MainWindow();
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
