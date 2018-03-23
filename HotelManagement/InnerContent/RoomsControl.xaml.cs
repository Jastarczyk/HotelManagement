﻿using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.IO;
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
                { availableRoom.Add(obj as Room); }

            SetRoomInformation(availableRoom.FirstOrDefault());
        }

        private void NavigateNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex < availableRoom.Count -1)
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
            //TODO rework this to binding source
            addingNewGuestSubContent.numberTextBox.Text = room.RoomNumber.ToString();
            addingNewGuestSubContent.specialNameTextBox.Text = room.SpecialName;
            addingNewGuestSubContent.areaTextBox.Text = room.Area.ToString();
            addingNewGuestSubContent.bedAmountTextBox.Text = room.BedsAmount.ToString();
            addingNewGuestSubContent.hasTVCheckBox.IsChecked = room.HasTelevistion;
            addingNewGuestSubContent.hasBalconyCheckBox.IsChecked = room.HasBalcon;
            addingNewGuestSubContent.ImageHolder.Source = (ImageSource)GetCurrentRoomImages(room).FirstOrDefault();
        }

        private List<object> GetCurrentRoomImages(Room room)
        {
             var urlList = HotelManagmentLogic.Helpers.DirectoryOperations.GetCurrentRoomImagesURL(room);


        }
    }
}
