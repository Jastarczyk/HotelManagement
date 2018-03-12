using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagmentLogic.Models.Acommodation
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [Required]
        public int RoomNumber {get; set;}

        [Required]
        public decimal Area { get; set; }

        [Required]
        public int BedsAmount { get; set; }

        [Required]
        public bool HasBalcon { get; set; }

        [Required]
        public bool HasTelevistion { get; set; }

        public string SpecialName { get; set; }

    }
}
