using HotelManagement.Registration;
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
        public static MainWindow mainWindow;
        public static LoginWindow loginWindow;
        public static RegistrationWindow registrationWindow;

        public WindowsManagement(Window startingWindow)
        {
            try
            {
                mainWindow = new MainWindow();
                registrationWindow = new RegistrationWindow();
                loginWindow = (LoginWindow)startingWindow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
