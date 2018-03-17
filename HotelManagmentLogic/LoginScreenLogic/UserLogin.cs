using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.DatabaseAccess;
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
        UserSecurity security = new UserSecurity();

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
                    //get user from database
                    User user = hotelContext.Users.Where(x => x.Username.Equals(userName)).ToList().FirstOrDefault();

                    //check if user exists
                    if (user == null)
                    {
                        return BuildOperationResult(OutputMessages.NoUserInDataBase, false, obj: user) as LoginResult;
                    }

                    //check password validation for founded user
                    if (!user.Password.Equals(String.Join(string.Empty, 
                        security.ValidateHashedPasswordSHA256(password, user.SaltValue).Select(x => Convert.ToChar(x)))))
                    {
                        return BuildOperationResult(OutputMessages.IncorrectPassowrd, false, obj: user) as LoginResult;
                    }

                    //return approving result if all steps were correct
                    return BuildOperationResult(OutputMessages.LoginSuccessfulMessage, true, obj: user) as LoginResult;
                }
            }

            catch (Exception ex)
            {
                Logger.ErrorLogger.AddLog(new Logger.ErrorLogger.Error(ex));
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
