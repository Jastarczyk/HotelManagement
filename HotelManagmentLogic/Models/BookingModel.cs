using HotelManagmentLogic.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models
{
    class BookingModel
    {
        [JsonProperty("BookingMethod")]
        public BookingMethods? BookingMethod { get; set; }

        [JsonProperty("BookingDate")]
        public DateTime? BookingDate { get; set; }

        [JsonProperty("ReservedFrom")]
        public DateTime ReservedFrom { get; set; }

        [JsonProperty("ReservedTo")]
        public DateTime ReservedTo { get; set; }
    }
}
