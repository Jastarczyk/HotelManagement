using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Entity.OperationResults;
using HotelManagmentLogic.GuestsControlLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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

        public static ReadDatabaseResult GetFullTableBaseOnType<T>() where T : class
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    hotelContext.Set<T>().Load();
                    return new DatabaseOperations().BuildReadOperationResult(hotelContext.Set<T>().Local, true);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseOperations().BuildReadOperationResult(new List<object>(), false, ex);
            }
        }

        private ReadDatabaseResult BuildReadOperationResult(IEnumerable<object> resultData, bool status, Exception exception = null)
        {
            AddToLoggerIfException(exception);

            return new ReadDatabaseResult()
            {
                ReturnedData = resultData,
                OperationSuccess = status,
                PossibleException = exception,
            };

        }

        private AddToDatabaseResult BuildOperationResult(bool status, string message, Exception exception = null)
        {
            AddToLoggerIfException(exception);

            return new AddToDatabaseResult()
            {
                OperationSuccess = status,
                Message = message,
                PossibleException = exception,
            };
        }

        private void AddToLoggerIfException(Exception exception)
        {
            if (exception != null)
            {
                Logger.ErrorLogger.AddLog(new Logger.ErrorLogger.Error(exception));
            }
        }

    }
}
