using HotelManagmentLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Acommodation.Abstract
{
    internal abstract class Room
    {
        public string SpecialName { get; set; }

        public int RoomNumber {get; set;}

        public decimal Area { get; set; }

        public int BedsAmount { get; set; }
    }
}
