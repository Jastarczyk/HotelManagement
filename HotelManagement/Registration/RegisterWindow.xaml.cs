using HotelManagmentLogic.LoginScreenLogic;
using HotelManagmentLogic.LoginScreenLogic.Abstract;
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
using System.Windows.Shapes;

namespace HotelManagement.Registration
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            RegistrationResult registrationResult = UserRegister.NewUser( UserTextBox.Text, 
                                                                          PasswordTextBox.Text, 
                                                                          ConfirmPasswordTextBox.Text, 
                                                                          NameTextBox.Text, 
                                                                          SurnameTextBox.Text);

            MessageBox.Show(registrationResult.RegistrationMessage);

            if (registrationResult.RegistrationSuccessful)
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
