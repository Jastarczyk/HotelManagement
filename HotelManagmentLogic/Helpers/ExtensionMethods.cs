using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Helpers
{
    public static class ExtensionMethods
    {
        public static List<T> ConvertToGenericList<T>(this IEnumerable<object> input) where T: class
        {
            List<T> outputList = new List<T>();

            foreach (object obj in input)
            {
                outputList.Add((T)obj);
            }

            return outputList;
        }
    }
}
