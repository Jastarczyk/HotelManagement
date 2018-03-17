using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.DatabaseAccess;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.LoginScreenLogic.Abstraction;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Linq;

namespace HotelManagmentLogic.LoginScreenLogic
{
    public class UserRegister : UserAccess
    {
        public RegistrationResult NewUser(string userName, string password, string confirmedPassword, string name, string surname)
        {
            if (!password.Equals(confirmedPassword))
            {
                return BuildOperationResult(OutputMessages.PasswordNoMatch, false) as RegistrationResult;
            }

            Tuple<bool, string> userValidation = CheckUserValidation(userName, password);

            if (!userValidation.Item1)
            {
                return BuildOperationResult(userValidation.Item2, false) as RegistrationResult;
            }


            Security security = new Security();

            Tuple<string, byte[]> hashingResults = security.HashPasswordSHA256(password);

            string saltValue = hashingResults.Item1;
            string hashedPassword = String.Join(String.Empty, hashingResults.Item2.ToList().Select( x => Convert.ToChar(x)));

            var localUser = new NewUserBuilder().SetUsername(userName)
                                                .SetPassword(hashedPassword)
                                                .GetSaltValue(saltValue)
                                                .SetName(name)
                                                .SetSurname(surname)
                                                .Build();

            try
            {
                //TODO check if can take duplicate user or exception because its a key for user
                AddToDatabaseResult result = DatabaseOperations.AddDataToHotelDatabase<User>(localUser);

                return result.OperationSuccess ? BuildOperationResult(OutputMessages.RegisterSuccessfulMessage, true, obj: localUser)
                                                 as RegistrationResult
                                               : BuildOperationResult(result.Message, result.OperationSuccess, result.PossibleException, localUser)
                                                 as RegistrationResult;
            }

            catch (Exception ex)
            {
                Logger.ErrorLogger.AddLog(new Logger.ErrorLogger.Error(ex));
                return BuildOperationResult(OutputMessages.InternalError, false, ex) as RegistrationResult;
            }
        }

        protected override AddToDatabaseResult BuildOperationResult(string message, bool status, Exception exception = null, object obj = null)
        {
            return new RegistrationResult()
            {
                Message = message,
                OperationSuccess = status,
                PossibleException = exception,
                RegisteringUser = (User)obj,
                RegistrationDate = DateTime.Now
            };
        }



    }
}
