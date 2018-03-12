using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.DatabaseAccess;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Models;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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

            roomsNumberList = RoomDbTableOperations.GetAllRoomsNumbersFromDB();
            this.roomChooseComboBox.ItemsSource = ConvertEachListElementToString(roomsNumberList);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool formatPredicate = CheckIfAllInformationFilled();

            if (formatPredicate)
            {
                Room choosedRoom = new Room();
                List<Room> roomsfullList = RoomDbTableOperations.GetAllRoomsFromDB();

                Booking bookingInfo = new Booking()
                {
                    //TODO TO TRYPARSE OR constatnt format (edit disable, can choose only by calendar)
                    BookingDate = DateTime.Now,
                    ReservedTo = DateTime.Parse(ToDateTextBox.Text),
                    ReservedFrom = DateTime.Parse(FromDateTextBox.Text),
                    //TODO add new feature to choose booking methods
                    BookingMethod = HotelManagmentLogic.Enums.BookingMethods.PersonalBooking
                };

                AddToDatabaseResult bookingInfoResults = DatabaseOperations.AddDataToHotelDatabase(bookingInfo);

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


        private bool CheckIfAllInformationFilled()
        {
            List<TextBox> controls = new List<TextBox>();

            try
            {
                object subcontentContent = addingNewGuestSubContent.Content;

                if (addingNewGuestSubContent.Content.GetType() != typeof(Grid))
                {
                    throw new InvalidCastException();
                }

                Grid subcontentGrid = subcontentContent as Grid;

                foreach (Control element in subcontentGrid.Children)
                {
                    if (element.GetType() == typeof(TextBox))
                    {
                        controls.Add(element as TextBox);
                    }
                }

                controls.Add(this.ToDateTextBox);
                controls.Add(this.FromDateTextBox);
            }
            catch (InvalidCastException ex)
            {
                //TODO: replace it with logger
                MessageBox.Show(ex.Message + ex.Source);
            }

            return controls.All(x => !string.IsNullOrEmpty(x.Text));
        }
    }
}
