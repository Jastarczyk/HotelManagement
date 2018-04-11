using HotelManagement.Management;
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
        //starting point of whole program
        public LoginWindow()
        {
            InitializeComponent();
            ProgramManagement.Initialize(this);
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
            //TODO remove it after finish end
            ProgramManagement.SetLoggedUser(new User() { Name = "Test user" });
            PrecedeToMainWindow();
        }

        private void PrecedeToMainWindow()
        {
            WindowsManagement.loginWindow.Close();
            WindowsManagement.CreateMainWindow();
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
            UserLogin userLogin = new UserLogin();

            LoginResult loginResult = userLogin.Login(this.UserTextBox.Text, this.UserPasswordTextBox.Password);
            MessageBox.Show(loginResult.Message);

            if (loginResult.OperationSuccess)
            {
                ProgramManagement.SetLoggedUser(loginResult.AccessingUser);
                PrecedeToMainWindow();
            }
        }
    }
}
