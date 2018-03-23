using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Entity.OperationResults
{
    interface IDatabaseResult
    {
        bool OperationSuccess { get; set; }
        Exception PossibleException { get; set; }
    }
}
