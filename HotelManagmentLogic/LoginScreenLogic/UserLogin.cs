using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.LoginScreenLogic.Abstraction;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Linq;

namespace HotelManagmentLogic.LoginScreenLogic
{
    public class UserLogin : UserAccess
    {
        public LoginResult Login(string userName, string password)
        {
            var userValidation = base.CheckUserValidation(userName, password);

            if (!userValidation.Item1)
            {
                return BuildOperationResult(userValidation.Item2, false) as LoginResult;
            }

            try
            {
                using (var hotelContext = new HotelContext())
                {
                    User user = hotelContext.Users.Where(x => x.Username.Equals(userName)).ToList().FirstOrDefault();

                    if (user == null)
                    {
                        return BuildOperationResult(OutputMessages.NoUserInDataBase, false, obj: user) as LoginResult;
                    }

                    if (!user.Password.Equals(password))
                    {
                        return BuildOperationResult(OutputMessages.IncorrectPassowrd, false, obj: user) as LoginResult;
                    }

                    return BuildOperationResult(OutputMessages.LoginSuccessfulMessage, true, obj: user) as LoginResult;
                }
            }

            catch (Exception ex)
            {
                return BuildOperationResult(message: OutputMessages.InternalError, status: false, exception: ex) as LoginResult;
            }
        }

        protected override AddToDatabaseResult BuildOperationResult(string message, bool status, Exception exception = null, object obj = null)
        {
            return new LoginResult()
            {
                Message = message,
                OperationSuccess = status,
                LoginTime = DateTime.Now,
                AccessingUser = (User) obj,
                PossibleException = exception
            };
        }
    }
}
