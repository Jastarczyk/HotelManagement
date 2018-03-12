using HotelManagmentLogic.Entity.DatabaseConfig;
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

            if (!DatabaseInfo.CheckDataBaseConnection())
            {
                MessageBox.Show(string.Format("{0} : {1}", HotelManagmentLogic.Configuration.OutputMessages.DataBaseConnectionError,
                                                           DatabaseInfo.GetDataBaseName()));

                Application.Current.Shutdown();
            }

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            userLogin = new UserLogin();

            LoginResult loginResult = userLogin.Login(this.UserTextBox.Text, this.UserPasswordTextBox.Password);
            MessageBox.Show(loginResult.Message);

            if (loginResult.OperationSuccess)
            {
                PrecedeToMainWindow();
            }
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
    }
}
