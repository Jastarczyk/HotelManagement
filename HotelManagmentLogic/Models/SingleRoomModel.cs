using HotelManagmentLogic.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models
{
    class SingleRoomModel : Room
    {
        public bool HasTelevistion { get; set; }
    }
}
