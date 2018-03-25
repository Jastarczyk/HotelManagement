using HotelManagement.InnerContent;
using HotelManagement.UserAccessUI;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.Models.Administration;
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
    public partial class MainWindow : Window, IDisposable
    {
        private static User currentUser;

        private Brush activeButtonColor = Brushes.AliceBlue;
        private Brush defaultButtonColor = Brushes.LightGray;

        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        private void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            InnerFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            InnerFrame.Content = new DashboardControl();
            DashboardButton.Background = activeButtonColor;
            DashboardButton.Focus();
        }


        private bool CheckIfContentActive<T>() where T : UserControl
        {
            return InnerFrame.Content.GetType() != typeof(T);
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {

            InnerFrame.Content = CheckIfContentActive<DashboardControl>() ? new DashboardControl()
                                                                          : InnerFrame.Content;
            DashboardButton.Background = activeButtonColor;
        }

        private void GuestsButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = CheckIfContentActive<GuestsControl>() ? new GuestsControl()
                                                                       : InnerFrame.Content;
            GuestsButton.Background = activeButtonColor;
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Content = CheckIfContentActive<RoomsControl>() ? new RoomsControl()
                                                                      : InnerFrame.Content;


            RoomsButton.Background = activeButtonColor;
        }

        private void AdministrationButton_Click(object sender, RoutedEventArgs e)
        {

            InnerFrame.Content = CheckIfContentActive<AdministrationControl>() ? new AdministrationControl()
                                                                               : InnerFrame.Content;

            AdministrationButton.Background = activeButtonColor;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ExitButton.Background = activeButtonColor;

            MessageBoxResult messageBoxResult = MessageBox.Show( HotelManagmentLogic.Configuration.OutputMessages.QuestionApplicationExit,
                                                                 HotelManagmentLogic.Configuration.OutputMessages.ApplicationClosingMessage, 
                                                                 MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Dispose();
            LoginWindow loginWindow = new LoginWindow();
            WindowsManagement.loginWindow.Show();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region Buttons: Lost Focus Event

        private void DashboardButton_LostFocus(object sender, RoutedEventArgs e)
        {
            DashboardButton.Background = defaultButtonColor;
        }

        private void GuestsButton_LostFocus(object sender, RoutedEventArgs e)
        {
            GuestsButton.Background = defaultButtonColor;
        }

        private void RoomsButton_LostFocus(object sender, RoutedEventArgs e)
        {
            RoomsButton.Background = defaultButtonColor;
        }

        private void AdministrationButton_LostFocus(object sender, RoutedEventArgs e)
        {
            AdministrationButton.Background = defaultButtonColor;
        }

        private void ExitButton_LostFocus(object sender, RoutedEventArgs e)
        {
            ExitButton.Background = defaultButtonColor;
        }

        private void LogOutButton_LostFocus(object sender, RoutedEventArgs e)
        {
            LogOutButton.Background = defaultButtonColor;
        }

        public void Dispose()
        {
            this.Close();
            GC.Collect();
        }
        #endregion
    }
}
