using HotelManagmentLogic.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Models.Administration
{
    [Table("Users")]
    public class UserModel
    {
        [Required]
        public Guid ID { get; set; }

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
