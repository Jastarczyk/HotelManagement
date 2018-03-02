using HotelManagmentLogic.GuestsControlLogic;
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

namespace HotelManagement.InnerContent.SubContent
{
    public partial class GuestRegisterControl : UserControl
    {
        public GuestRegisterControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            GuestRegister guestRegister = new GuestRegister();

            AddNewGuestResult result = guestRegister.Add( NameTextBox.Text, 
                                                          SurnameTextBox.Text, 
                                                          EmailTextBox.Text,
                                                          MobileNumberTextBox.Text, 
                                                          AddressTextBox.Text);
            MessageBox.Show(result.Message);
        }
    }
}
