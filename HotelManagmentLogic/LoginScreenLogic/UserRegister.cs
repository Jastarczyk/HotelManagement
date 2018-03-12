using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Entity.DatabaseConfig;
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

            var localUser = new NewUserBuilder().SetUsername(userName)
                                                .SetPassword(password)
                                                .SetName(name)
                                                .SetSurname(surname)
                                                .Build();

            Tuple<bool, string> userValidation = CheckUserValidation(localUser.Name, localUser.Password);

            if (!userValidation.Item1)
            {
                return BuildOperationResult(userValidation.Item2, false) as RegistrationResult;
            }
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
