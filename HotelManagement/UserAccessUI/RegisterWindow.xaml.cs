using HotelManagmentLogic.LoginScreenLogic;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using System;
using System.Windows;

namespace HotelManagement.UserAccessUI
{
    public partial class RegistrationWindow : Window
    {
        UserRegister userRegister;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            userRegister = new UserRegister();

            RegistrationResult registrationResult = userRegister.NewUser( UserTextBox.Text, 
                                                                          PasswordTextBox.Password, 
                                                                          ConfirmPasswordTextBox.Password, 
                                                                          NameTextBox.Text, 
                                                                          SurnameTextBox.Text);

            MessageBox.Show(registrationResult.Message);

            if (registrationResult.OperationSuccess)
            {
                WindowsManagement.registrationWindow.Hide();
                WindowsManagement.loginWindow.Show();
            }
        
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsManagement.registrationWindow.Hide();
            WindowsManagement.loginWindow.Show();
        }
    }
}
