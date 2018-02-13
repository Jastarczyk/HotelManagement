using HotelManagmentLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models
{
    class BookingModel
    {
        public BookingMethods? BookingMethod { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedTo { get; set; }
    }
}
