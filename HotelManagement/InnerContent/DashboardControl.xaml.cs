using HotelManagmentLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement.InnerContent
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {

        public DashboardControl()
        {
            InitializeComponent();
            Task.Run(() => StartClock());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillStartingDashboardContent();
        }

        private void FillStartingDashboardContent()
        {
            //get booked guest data from db
            List<Guest> currentGuests = HotelManagmentLogic.DatabaseAccess.RoomDbTableOperations.GetAllGuestList();
            Guest lastBookedGuest = currentGuests.Where(x => x.ID >= currentGuests.Max(n => n.ID)).FirstOrDefault();

            //title - logging user
            UsernameTextBoxWelcome.Text = WindowsManagement.GetMainWindowInstance().GetCurrentUser().Name;

            //booked guest amount - fill x/x format and also progress bar
            currentGuestAmount.Text = currentGuests.Count.ToString();
            guestProgressBar.Value = Int32.Parse(currentGuestAmount.Text);

            lastRegisteredGuestTextBox.Text = string.Format("{0}\r\n{1}", lastBookedGuest.Name?? string.Empty, lastBookedGuest.Surname?? string.Empty);
        }

        #region Clock functionality

        private void StartClock()
        {
            while (true)
            {
                UpdateClock();
                Thread.Sleep(50);
            }
        }

        private void UpdateClock()
        {
           Dispatcher.Invoke(() =>
           {
               this.CalendarTextbox.Text = DateTime.Now.ToShortDateString();
               this.ClockTextBox.Text = DateTime.Now.ToLongTimeString();
           });
        }

        #endregion

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
           //TODO end this (throw and exeption when on program close (Async task)
        }
    }
}
