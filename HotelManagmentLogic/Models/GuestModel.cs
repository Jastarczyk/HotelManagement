using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models
{
    class GuestModel
    {
        [JsonProperty("ID")]
        public Guid ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("TelephoneNumber")]
        public long TelephoneNumber { get; set; }
    }
}
