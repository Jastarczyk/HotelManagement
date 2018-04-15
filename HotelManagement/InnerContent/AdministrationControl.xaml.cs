using HotelManagement.InnerContent.SubContent;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.Helpers;
using HotelManagmentLogic.Models.Administration;
using System.Windows;
using System.Windows.Controls;


namespace HotelManagement.InnerContent
{
    /// <summary>
    /// Interaction logic for AdministrationControl.xaml
    /// </summary>
    public partial class AdministrationControl : UserControl
    {
        public AdministrationControl()
        { 
            InitializeComponent();
            FillRegisteredUserListView();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = RegisteredUserListView.SelectedItem as User;
            EditPermissionWindow editPermissionControl = new EditPermissionWindow(selectedUser);
            editPermissionControl.Show();
        }

        private void FillRegisteredUserListView()
        {
            RegisteredUserListView.ItemsSource = DatabaseOperations.GetFullTableBaseOnType<User>()
                                                                   .ReturnedData
                                                                   .ConvertToGenericList<User>();
        }

        public void RefreshRegisteredUserList()
        {
            FillRegisteredUserListView();
        }

        private void RegisteredUserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegisteredUserListView.SelectedItem != null)
            {
                User selectedUser = RegisteredUserListView.SelectedItem as User;
                FillPermissionUserType(selectedUser.UserType);
            }
        }

        //TODO add possibility to edit user type by administrator
        private void FillPermissionUserType(UserType userType)
        {
            Permission permissions;

            switch(userType)
            {
                case UserType.Administrator:
                    permissions = new HotelManagmentLogic.Security.Administrator().GetDefaultPermissions();
                    break;

                case UserType.Common:
                    permissions = new HotelManagmentLogic.Security.CommonUser().GetDefaultPermissions();
                    break;

                case UserType.Manager:
                    permissions = new HotelManagmentLogic.Security.Manager().GetDefaultPermissions();
                    break;

                default:
                    return;
            }

            FillPermissionCheckBoxes(permissions);
        }

        private void FillPermissionCheckBoxes(Permission permissions)
        {
            PermissionAddNewGuestCheckBox.IsChecked = permissions.CanBookGuest;
            SeeBookedGuestList.IsChecked = permissions.BookedGuestListPreview;
            AddNewUserCheckBox.IsChecked = permissions.CanAddUser;
            AccesToAdminPanelCheckBox.IsChecked = permissions.HasAccessToAdminPanel;
            PermissionEditAdminPanelCheckBox.IsChecked = permissions.CanEditPermissionInAdminPanel;
        }
    }
}
