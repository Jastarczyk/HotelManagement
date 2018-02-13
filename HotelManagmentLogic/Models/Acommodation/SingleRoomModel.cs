using HotelManagmentLogic.Models.Acommodation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Acommodation
{
    class SingleRoomModel : Room
    {
        public bool HasTelevistion { get; set; }
    }
}
