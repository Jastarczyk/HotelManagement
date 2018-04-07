using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HotelManagement.InnerContent
{
    /// <summary>
    /// Interaction logic for RoomsControl.xaml
    /// </summary>
    public partial class RoomsControl : UserControl
    {
        private int pageIndex = default(int);
        private List<Room> availableRoom = new List<Room>();

        public RoomsControl()
        {
            InitializeComponent();

            IEnumerable<object> dbReadResult = DatabaseOperations.GetFullTableBaseOnType<Room>().ReturnedData;

            foreach (object obj in dbReadResult)
            {
                availableRoom.Add(obj as Room);
            }
            SetRoomInformation(availableRoom.FirstOrDefault());
        }

        private void NavigateNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex < availableRoom.Count - 1)
            {
                pageIndex++;
                SetRoomInformation(availableRoom[pageIndex]);
            }
        }

        private void NavigateBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex--;
                SetRoomInformation(availableRoom[pageIndex]);
            }
        }

        private void SetRoomInformation(Room room)
        {
            if (room != null)
            {
                addingNewGuestSubContent.numberTextBox.Text = room.RoomNumber.ToString();
                addingNewGuestSubContent.specialNameTextBox.Text = room.SpecialName;
                addingNewGuestSubContent.areaTextBox.Text = room.Area.ToString();
                addingNewGuestSubContent.bedAmountTextBox.Text = room.BedsAmount.ToString();
                addingNewGuestSubContent.hasTVCheckBox.IsChecked = room.HasTelevistion;
                addingNewGuestSubContent.hasBalconyCheckBox.IsChecked = room.HasBalcon;
                addingNewGuestSubContent.ImageHolder.Source = GetCurrentRoomImages(room).FirstOrDefault() as ImageSource;
                // up ^ FirstOrDefoult was used because there is no need to get images colllection at this moment
            }
        }

        private List<object> GetCurrentRoomImages(Room room)
        {
            List<object> imageList = new List<object>();

            var urlList = HotelManagmentLogic.Helpers.DirectoryOperations.GetCurrentRoomImagesURL(room);

            foreach (string url in urlList)
            {
                imageList.Add(new BitmapImage(new Uri(url)));
            }

            return imageList;
        }
    }
}
