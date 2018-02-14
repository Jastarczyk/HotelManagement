using HotelManagmentLogic.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Acommodation.Abstract
{
    internal abstract class Room
    {
        [JsonProperty("SpecialName")]
        public string SpecialName { get; set; }

        [JsonProperty("RoomNumber")]
        public int RoomNumber {get; set;}

        [JsonProperty("Area")]
        public decimal Area { get; set; }

        [JsonProperty("BedsAmount")]
        public int BedsAmount { get; set; }
    }
}
