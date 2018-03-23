using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Entity.OperationResults
{
    public class ReadDatabaseResult : IDatabaseResult
    {
        public IEnumerable<object> ReturnedData { get; set; }
        public bool OperationSuccess { get; set; }
        public Exception PossibleException { get; set; }
    }
}
