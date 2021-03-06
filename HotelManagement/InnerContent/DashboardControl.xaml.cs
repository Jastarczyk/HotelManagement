﻿using HotelManagement.Management;
using HotelManagmentLogic.Helpers;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.InnerContent
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {

        public DashboardControl()
        {
            InitializeComponent();
            Task.Run(() => StartClock());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillStartingDashboardContent();
        }

        private void FillStartingDashboardContent()
        {
            //get info from data base to use it later
            List<Guest> currentGuests = HotelManagmentLogic.Entity.CommonOperations.DatabaseOperations
                                                           .GetFullTableBaseOnType<Guest>()
                                                           .ReturnedData
                                                           .ConvertToGenericList<Guest>();

            List<Booking> bookingTable = HotelManagmentLogic.Entity.CommonOperations.DatabaseOperations
                                                            .GetFullTableBaseOnType<Booking>()
                                                            .ReturnedData
                                                            .ConvertToGenericList<Booking>();

            //fill box about last booked guest and store that variable
            Guest lastBookedGuest = FillLastBookedGuestOutput(currentGuests);

            //fill box which represent logged user name
            UsernameTextBoxWelcome.Text = ProgramManagement.GetLoggedUser().Name;

            //booked guest amount - fill x/x format and also progress bar
            FillGuestCurrentGuestCountOutput(currentGuests);

            //inner join booking and guests table to get data about closest booking end date
            FillClosestBookEndingOutput(bookingTable, currentGuests, lastBookedGuest);
        }

        #region UserOutputFillers

        private void FillClosestBookEndingOutput(List<Booking> bookingTable, List<Guest> currentGuests, Guest lastBookedGuest)
        {
            var innerJoinResult = bookingTable.Join(currentGuests, booking => booking.ID, guest => guest.BookingID,
              (booking, guest) =>
              {
                  return new Tuple<DateTime, List<string>>(booking.ReservedTo, new List<string>()
                  {
                      guest.Name,
                      guest.Surname
                  }); 
              }).OrderBy(x => x.Item1);

            lastRegisteredGuestTextBox.Text = string.Format("{0}\r\n{1}", lastBookedGuest.Name ?? string.Empty, lastBookedGuest.Surname ?? string.Empty);

            try
            {
                ClosestBookEndTextBox.Text = innerJoinResult.FirstOrDefault()
                                                            .Item1
                                                            .ToShortDateString() + " \r\n" + innerJoinResult.FirstOrDefault().Item2[0]
                                                                                 + "\r\n" + innerJoinResult.FirstOrDefault().Item2[1];
            }
            catch (Exception)
            {
                ClosestBookEndTextBox.Text = string.Empty;
            }
        }

        private void FillGuestCurrentGuestCountOutput(List<Guest> currentGuests)
        {
            currentGuestAmount.Text = currentGuests.Count.ToString();
            guestProgressBar.Value = Int32.Parse(currentGuestAmount.Text);
        }

        private Guest FillLastBookedGuestOutput(List<Guest> currentGuests)
        {
            Guest lastBookedGuest = currentGuests.Where(x => x.ID >= currentGuests.Max(n => n.ID)).FirstOrDefault();
            maxGuestNumber.Text = ((int)guestProgressBar.Maximum).ToString();

            return lastBookedGuest;
        }

        #endregion

        #region Clock functionality

        private void StartClock()
        {
            while (true)
            {
                UpdateClock();
                Thread.Sleep(50);
            }
        }

        private void UpdateClock()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    this.CalendarTextbox.Text = DateTime.Now.ToShortDateString();
                    this.ClockTextBox.Text = DateTime.Now.ToLongTimeString();
                });
            }
            catch (Exception)
            {
                //silented
            }
        }

        #endregion
    }
}
