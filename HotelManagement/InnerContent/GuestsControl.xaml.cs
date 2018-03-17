using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.DatabaseAccess;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Logger;
using HotelManagmentLogic.Models;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HotelManagement.InnerContent
{
    /// <summary>
    /// Interaction logic for GuestsControl.xaml
    /// </summary>
    public partial class GuestsControl : UserControl
    {
        private List<int> roomsNumberList;

        public GuestsControl()
        {
            InitializeComponent();
            LoadCurrentControlContent();
        }

        private void LoadCurrentControlContent()
        {
            roomsNumberList = RoomDbTableOperations.GetAllRoomsNumbersFromDB();
            this.roomChooseComboBox.ItemsSource = ConvertEachListElementToString(roomsNumberList);
            this.BookingMethodsCombobox.ItemsSource = Enum.GetValues(typeof(BookingMethods));

            this.BookingMethodsCombobox.Text = BookingMethodsCombobox.Items.Count > 0 ?
                                               BookingMethodsCombobox.Items.GetItemAt(0).ToString() 
                                               : string.Empty;
        }

        //TODO move this logic to other project!
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool formatPredicate = CheckIfAllInputsFilled();

            if (formatPredicate)
            {
                Room choosedRoom = new Room();
                Booking bookingInfo = new Booking();
                AddToDatabaseResult bookingInfoResults;
                List<Room> roomsfullList = RoomDbTableOperations.GetAllRoomsFromDB();

                try
                {
                    bookingInfo = new Booking()
                    {
                        BookingDate = DateTime.Now,
                        ReservedTo = DateTime.TryParse(ToDateTextBox.Text, out DateTime toDate) ? toDate 
                                                                                                : throw new InvalidCastException(),
                        ReservedFrom = DateTime.TryParse(FromDateTextBox.Text, out DateTime fromDate) ? fromDate 
                                                                                                      : throw new InvalidCastException(),
                        BookingMethod = (BookingMethods)Enum.Parse(typeof(BookingMethods), BookingMethodsCombobox.Text)
                    };
                }
                catch (InvalidCastException ex)
                {
                    ErrorLogger.AddLog(new ErrorLogger.Error(ex));
                }

                bookingInfoResults = DatabaseOperations.AddDataToHotelDatabase(bookingInfo);

                for (int index = 0; index < roomsfullList.Count; index++)
                {
                    if (roomsfullList[index].RoomNumber.ToString().Equals(roomChooseComboBox.Text.Last().ToString()))
                    {
                        choosedRoom = roomsfullList[index];
                    }
                }

                Guest buildedGuest = new GuestBuilder().SetName(addingNewGuestSubContent.NameTextBox.Text)
                                                       .SetSurname(addingNewGuestSubContent.SurnameTextBox.Text)
                                                       .SetEmail(addingNewGuestSubContent.EmailTextBox.Text)
                                                       .SetTelephoneNumber(addingNewGuestSubContent.MobileNumberTextBox.Text)
                                                       .SetAddress(addingNewGuestSubContent.AddressTextBox.Text)
                                                       .SetRoom(choosedRoom.RoomNumber)
                                                       .SetBooking(bookingInfo.ID)
                                                       .Build();

                AddToDatabaseResult buildedGuestResults = DatabaseOperations.AddDataToHotelDatabase(buildedGuest);

                if (buildedGuestResults.OperationSuccess && bookingInfoResults.OperationSuccess)
                {
                    MessageBox.Show(OutputMessages.DataBaseInsertSuccess);
                }
            }
            else
            {
                MessageBox.Show(OutputMessages.MissingArgumentsMessage);
            }
        }

        private List<string> ConvertEachListElementToString(List<int> toConvert)
        {
            List<string> localList = new List<string>();

            foreach (int element in toConvert)
            {
                localList.Add(String.Format("{0}: {1}", OutputMessages.RoomDisplayMessage, element.ToString()));
            }

            return localList;
        }

        private List<T> GetChildsFromDependencyObject<T>(DependencyObject depObj) where T: UIElement
        {
            List<T> controls = new List<T>();

            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(depObj); index++)
            {
                if (VisualTreeHelper.GetChild(depObj, index).GetType() == typeof(T))
                {
                    controls.Add(VisualTreeHelper.GetChild(depObj, index) as T);
                }
            }

            return controls;
        }

        private bool CheckIfAllInputsFilled()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            List<ComboBox> comboBoxes = new List<ComboBox>();

            try
            {
                textBoxes = GetChildsFromDependencyObject<TextBox>(addingNewGuestSubContent.Content as DependencyObject);
                comboBoxes = GetChildsFromDependencyObject<ComboBox>(MainGrid);
            }
            catch (InvalidCastException ex)
            {
                ErrorLogger.AddLog(new ErrorLogger.Error(ex));
            }

            return textBoxes.All(x => !string.IsNullOrEmpty(x.Text)) && comboBoxes.All(x => !string.IsNullOrEmpty(x.Text));
        }
    }
}
