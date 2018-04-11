using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelManagmentLogic.Models.Acommodation;

namespace HotelManagmentLogic.Models.Administration
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public int BookingID { get; set; }

        [ForeignKey("BookingID")]
        public Booking BookingFK { get; set; }

        [Required]
        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room RoomFK { get; set; }

    }
}
