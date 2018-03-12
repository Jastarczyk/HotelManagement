using HotelManagmentLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.GuestsControlLogic
{
    public class AddToDatabaseResult
    {
        public bool OperationSuccess { get; set; }
        public string Message { get; set; }
        public Exception PossibleException { get; set; } = null;
    }
}
