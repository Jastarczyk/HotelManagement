using HotelManagmentLogic.Models.Acommodation.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Acommodation
{
    class ApartamentModel : Room
    {
        [JsonProperty("LivingRoomsAmount")]
        public int LivingRoomsAmount { get; set; }

        [JsonProperty("ToiletsAmount")]
        public int ToiletsAmount { get; set; }

        [JsonProperty("KitchenAmount")]
        public int KitchenAmount { get; set; }

        [JsonProperty("HasBalcon")]
        public bool HasBalcon { get; set; }
    }
}
