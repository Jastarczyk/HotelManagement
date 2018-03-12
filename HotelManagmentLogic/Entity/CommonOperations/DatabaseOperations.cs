using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.GuestsControlLogic;
using System;

namespace HotelManagmentLogic.Entity.CommonOperations
{
    public class DatabaseOperations
    {
        public static AddToDatabaseResult AddDataToHotelDatabase<T>(T dataToAdd) where T : class
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    hotelContext.Set<T>().Add(dataToAdd);
                    hotelContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseOperations().BuildOperationResult(false, Configuration.OutputMessages.DataBaseInsertFailed, ex);
            }

            return new DatabaseOperations().BuildOperationResult(true, Configuration.OutputMessages.DataBaseInsertSuccess);
        }


        private AddToDatabaseResult BuildOperationResult(bool status, string message, Exception exception = null)
        {
            return new AddToDatabaseResult()
            {
                OperationSuccess = status,
                Message = message,
                PossibleException = exception,
            };
        }

    }
}
