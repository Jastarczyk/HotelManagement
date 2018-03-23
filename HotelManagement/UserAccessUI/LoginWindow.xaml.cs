using HotelManagmentLogic.DatabaseAccess;
using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Logger;
using HotelManagmentLogic.LoginScreenLogic;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using System.Windows;

namespace HotelManagement.UserAccessUI
{
    public partial class LoginWindow : Window
    {
        WindowsManagement windowsManagement;
        UserLogin userLogin;

        public LoginWindow()
        {
            InitializeComponent();
            windowsManagement = new WindowsManagement(this);

            //TODO uncomment this

            //if (!DatabaseInfo.CheckDataBaseConnection())
            //{
            //    MessageBox.Show(HotelManagmentLogic.Configuration.OutputMessages.DataBaseConnectionError, DatabaseInfo.GetDataBaseName());
            //    Application.Current.Shutdown();
            //}

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
            PrecedeToMainWindow();
        }

        private void PrecedeToMainWindow()
        {
            WindowsManagement.loginWindow.Close();
            WindowsManagement.mainWindow.Show();
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
                PrecedeToMainWindow();
            }
        }
    }
}
