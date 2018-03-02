using HotelManagement.InnerContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HotelManagement
{
    public partial class MainWindow : Window
    {
        private UserControl dashboardControl;
        private UserControl guestsControl;
        private UserControl roomsControl;
        private UserControl administrationControl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            InnerFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            //for a small application it should be not a such a problem to store all control in memory
            dashboardControl = new DashboardControl();
            guestsControl = new GuestsControl();
            roomsControl = new RoomsControl();
            administrationControl = new AdministrationControl();

            InnerFrame.Content = dashboardControl;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = dashboardControl;
        }

        private void GuestsButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = guestsControl;
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = roomsControl;
        }

        private void AdministrationButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = administrationControl;
        }
    }
}
