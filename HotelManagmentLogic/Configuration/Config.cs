using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Configuration
{
    internal static class Config
    {
        public const int MinimumUserLenght = 5;
        public const int MaxUserLength = 25;

        public const int MinimumPasswordLenght = 5;
        public const int MaxPasswordLength = 25;

        public const string SpecialCharactersPattern = "^[a-zA-Z0-9]+$";

    }
}
