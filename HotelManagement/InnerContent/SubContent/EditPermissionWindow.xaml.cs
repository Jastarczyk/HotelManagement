using HotelManagement.Management;
using HotelManagmentLogic.Entity.SpecificOperations;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Logger;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Windows;

namespace HotelManagement.InnerContent.SubContent
{
    /// <summary>
    /// Interaction logic for EditPermissionWindow.xaml
    /// </summary>
    public partial class EditPermissionWindow : Window, IDisposable
    {
        private User selectedUser;

        public EditPermissionWindow(User selectedUser)
        {
            InitializeComponent();
            this.selectedUser = selectedUser;
        }

        public void Dispose()
        {
            this.Close();
        }

        private void UserTypesComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                this.userNameHolderTextBox.Text = selectedUser.Username;
                this.UserTypesComboBox.ItemsSource = Enum.GetNames(typeof(UserType));
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserTypesComboBox.SelectedItem == null)
            {
                MessageBox.Show(HotelManagmentLogic.Configuration.OutputMessages.MissingArgumentsMessage);
                return;
            }
            try
            {
                if (Enum.TryParse<UserType>(UserTypesComboBox.SelectedValue.ToString(), out UserType parsedUserType))
                {
                    AddToDatabaseResult result = UserDatabaseOperations.ChangeUserPermissions(selectedUser, parsedUserType);
                    MessageBox.Show(result.Message);

                    WindowsManagement.GetAdministrationControlInstance().RefreshRegisteredUserList();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.AddLog(new ErrorLogger.Error(ex));
            }
        }
    }
}
