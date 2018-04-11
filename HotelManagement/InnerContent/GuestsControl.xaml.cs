using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Helpers;
using HotelManagmentLogic.Logger;
using HotelManagmentLogic.Models.Acommodation;
using HotelManagmentLogic.Models.Administration;
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

        /// <summary>
        /// Method using for fill out default window's content information 
        /// </summary>
        private void LoadCurrentControlContent()
        {
            roomsNumberList = DatabaseOperations.GetFullTableBaseOnType<Room>().ReturnedData.ConvertToGenericList<Room>().Select(x => x.RoomNumber).ToList();
            this.roomChooseComboBox.ItemsSource = ConvertEachListElementToString(roomsNumberList);
            this.BookingMethodsCombobox.ItemsSource = Enum.GetValues(typeof(BookingMethods));

            this.BookingMethodsCombobox.Text = BookingMethodsCombobox.Items.Count > 0 ?
                                               BookingMethodsCombobox.Items.GetItemAt(0).ToString() 
                                               : string.Empty;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool formatPredicate = CheckIfAllInputsFilled();

            if (formatPredicate)
            {
                //Creating objects to fill with data from user input (and then add them to db)
                Room choosedRoom = new Room();
                Booking bookingInfo = new Booking();
                AddToDatabaseResult bookingInfoResults;
                List<Room> roomsfullList = DatabaseOperations.GetFullTableBaseOnType<Room>().ReturnedData.ConvertToGenericList<Room>();

                try
                {
                    bookingInfo = new Booking()
                    {
                        BookingDate = DateTime.Now,
                        ReservedTo = ToDatePicker.SelectedDate?? DateTime.MaxValue,
                        ReservedFrom = FromDatePicker.SelectedDate ?? DateTime.MinValue.Date,
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

                MessageBox.Show((buildedGuestResults.OperationSuccess && bookingInfoResults.OperationSuccess) ? 
                    OutputMessages.DataBaseInsertSuccess : OutputMessages.FailedAddedToDatabase);
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
            //TODO : make this method more ELASTIC for changes (should take all control to 1 list and then check for valid input)
            List<TextBox> textBoxes = new List<TextBox>();
            List<ComboBox> comboBoxes = new List<ComboBox>();
            List<DatePicker> datePickers = new List<DatePicker>()
            { this.FromDatePicker, this.ToDatePicker };

            try
            {
                textBoxes = GetChildsFromDependencyObject<TextBox>(addingNewGuestSubContent.Content as DependencyObject);
                comboBoxes = GetChildsFromDependencyObject<ComboBox>(MainGrid);
            }
            catch (InvalidCastException ex)
            {
                ErrorLogger.AddLog(new ErrorLogger.Error(ex));
            }

            return textBoxes.All(x => !string.IsNullOrEmpty(x.Text)) 
                   && comboBoxes.All(x => !string.IsNullOrEmpty(x.Text))
                   && datePickers.All(x => x.SelectedDate != null);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            guestDataGrid.ItemsSource = DatabaseOperations.GetFullTableBaseOnType<Guest>().ReturnedData;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }
    }
}
