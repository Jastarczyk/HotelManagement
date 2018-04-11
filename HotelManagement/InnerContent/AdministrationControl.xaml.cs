using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.Helpers;
using HotelManagmentLogic.Models.Administration;
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

        private void FillRegisteredUserListView()
        {
            RegisteredUserListView.ItemsSource = DatabaseOperations.GetFullTableBaseOnType<User>()
                                                                    .ReturnedData
                                                                    .ConvertToGenericList<User>();
        }

        private void RegisteredUserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool dataValid = e.AddedItems.Count > default(int) ? e.AddedItems[0].GetType() == typeof(User)
                                                : false;

            User selectedUser = dataValid ? e.AddedItems.Cast<User>().FirstOrDefault()
                                          : new User();

            FillPermissionUserType(selectedUser.UserType);

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
                
                //TODO add manager

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
