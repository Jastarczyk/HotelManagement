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
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            userLogin = new UserLogin();

            LoginResult loginResult = userLogin.Login(this.UserTextBox.Text, this.UserPasswordTextBox.Password);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsManagement.loginWindow.Hide();
            WindowsManagement.registrationWindow.Show();
        }
    }
}
