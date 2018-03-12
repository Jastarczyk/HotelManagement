using HotelManagmentLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagmentLogic.Models.Administration
{
    [Table("Users")]
    public class User
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MinLength(Configuration.Config.MinimumUserLenght)]
        [MaxLength(Configuration.Config.MaxUserLength)]
        [Key]
        public string Username { get; set; }

        [Required]
        [MinLength(Configuration.Config.MinimumPasswordLenght)]
        [MaxLength(Configuration.Config.MaxPasswordLength)]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatingDate { get; set; }
    }
}
