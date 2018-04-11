using HotelManagmentLogic.Enums;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagmentLogic.Models.Administration
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public BookingMethods? BookingMethod { get; set; }

        [Required]
        public DateTime? BookingDate { get; set; }

        [Required]
        public DateTime ReservedFrom { get; set; }

        [Required]
        public DateTime ReservedTo { get; set; }
    }
}
