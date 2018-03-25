using HotelManagmentLogic.DatabaseAccess;
using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Logger;
using HotelManagmentLogic.LoginScreenLogic;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using HotelManagmentLogic.Models.Administration;
using System.Windows;

namespace HotelManagement.UserAccessUI
{
    public partial class LoginWindow : Window
    {
        WindowsManagement windowsManagement;
        UserLogin userLogin;

        //starting point of whole program
        public LoginWindow()
        {
            InitializeComponent();
            //set starting windows
            windowsManagement = new WindowsManagement(this);

            //check connection to database 
            if (!DatabaseInfo.CheckDataBaseConnection())
            {
                MessageBox.Show(HotelManagmentLogic.Configuration.OutputMessages.DataBaseConnectionError, DatabaseInfo.GetDataBaseName());
                Application.Current.Shutdown();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PerformLoginAction();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsManagement.loginWindow.Hide();

            WindowsManagement.registrationWindow = new RegistrationWindow();
            WindowsManagement.registrationWindow.Show();
        }

        private void ForceLogin_Click(object sender, RoutedEventArgs e)
        {
            PrecedeToMainWindow(new User() { Name = "TestingUser" });
        }

        private void PrecedeToMainWindow(User loggedUser)
        {
            WindowsManagement.loginWindow.Close();
            WindowsManagement.CreateMainWindow(loggedUser);
            WindowsManagement.ShowMainWindow();
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                PerformLoginAction();
            }
        }

        private void PerformLoginAction()
        {
            userLogin = new UserLogin();

            LoginResult loginResult = userLogin.Login(this.UserTextBox.Text, this.UserPasswordTextBox.Password);
            MessageBox.Show(loginResult.Message);

            if (loginResult.OperationSuccess)
            {
                PrecedeToMainWindow(loginResult.AccessingUser);
            }
        }
    }
}
