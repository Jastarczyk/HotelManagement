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
        [MinLength(Configuration.Config.MinimumUserLenght)]
        [MaxLength(Configuration.Config.MaxUserLength)]
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime CreatingDate { get; set; }

        [Required]
        public string SaltValue { get; set; }
    }
}
