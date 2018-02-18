using HotelManagmentLogic.LoginScreenLogic;
using System.Windows;

namespace HotelManagement
{
    public partial class LoginWindow : Window
    {
        WindowsManagement windowsManagement;

        public LoginWindow()
        {
            InitializeComponent();
            windowsManagement = new WindowsManagement(this);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserValidation.Login(this.UserTextBox.Text, this.UserPasswordTextBox.Text);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsManagement.loginWindow.Hide();
            WindowsManagement.registrationWindow.Show();
        }
    }
}
